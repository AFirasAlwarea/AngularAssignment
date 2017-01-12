var app = angular.module("myApp", []);
app.controller("myController", function ($scope, $http, $log) {

    $scope.message = "Single Page Application";

    var ListOnDemand = function (response) {
        $scope.PersonsList = response.data;
        $http.get("/Persons/GiveMeList")
            .then(onMyList, onError);
    };

    var onMyList = function (response) {
        $scope.PersonsList = response.data;
    };

    var onError = function (reason) {
        $scope.error = "Couldn't get the data!";
    };

    $scope.ShowList = function () {
        $http.get("/Persons/GiveMeList")
          .then(ListOnDemand, onError);
    };

    var thisOneUser = function (response) {
        console.log(response.data);
        $scope.onePerson = response.data;
    };

    //$scope.showDetails = function (userName) {
    //    $http.post("/Persons/FullDetails", userName)
    //        .then(thisOneUser,onError);
    //};
    $scope.showDetails = function (userName) {
        $http({
            method: "POST",
            url: "/Persons/FullDetails",
            data: {
                userName: userName
            }
        }).then(thisOneUser, onError);
    };
});