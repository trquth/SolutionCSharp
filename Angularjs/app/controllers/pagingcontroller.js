app.controller("pagingCtrl", function ($scope, $filter, ngTableParams, pagingservice) {
    var dataobj  =;
    var init= function ()
    {
        pagingservice.getAllData().success(function (data) {
           $scope.data = data;
        });
    }
    init();
    $scope.dosearch = function () {
        $scope.tableparams.reload();
    };
    $scope.tableParams = new ngTableParams({
        page: 1,
        count: 10,
        sorting: {
            name:'asc'
        }
    }, {
        count:[],
        total: dataobj.length,
        getData: function ($defer,params) {
            $scope.x = params.sorting();
            var processedData = $filter('filter')(dataobj, $scope.filter);
            processedData = $filter('orderBy')(dataobj, params.orderBy());
            params.total(processedData.length); // set total for recalc pagination
            $defer.resolve(processedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
        }
    });
})