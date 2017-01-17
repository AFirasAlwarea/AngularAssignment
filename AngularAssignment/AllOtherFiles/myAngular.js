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

    var editPerson = function (response) {
        console.log(response.data);
        $scope.editPerson = response.data;
    };

    $scope.Edit = function (Id) {
        console.log(Id);
        $http({
            method: "POST",
            url: "/Persons/Edit",
            data: {
                Id: Id
            }
        }).then(editPerson, onError);
    };

    $scope.SaveEdit = function (editPerson) {
        
        $http({
            method: "POST",
            url: "/Persons/SaveEdit",
            data: {
                Id: editPerson.Id,
                Name: editPerson.Name,
                Email: editPerson.Email,
                Telephone: editPerson.Telephone
            }
        }).then(editPerson, onError);
    };

    $scope.ShowCreate = function () {
        $scope.shoCreate = true;
    };

    $scope.SaveCreate = function (createPerson) {
        $http({
            method: "POST",
            url: "/Persons/Create",
            data: {
                Id: createPerson.Id,
                Name: createPerson.Name,
                Email: createPerson.Email,
                Telephone: createPerson.Telephone
            }
        }).then(onMyList, onError);
        $scope.shoCreate = false;
    };
});