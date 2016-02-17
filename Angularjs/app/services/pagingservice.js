app.factory("pagingservice", function ($http) {
    var getAllData = function () {
        return $http.get("demo.json");
    }
    return {
        getAllData:getAllData
    }
})