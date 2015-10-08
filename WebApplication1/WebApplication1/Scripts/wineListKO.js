
(function () {
    var viewModel = function () {
        var self = this;

        var IsUpdatable = false;

        self.ID = ko.observable(0);
        self.Title = ko.observable("");
        self.Color = ko.observable("");
        self.TermExposure = ko.observable("");
        self.Fortress = ko.observable("");
        self.Price = ko.observable("");

        var WineInfo = {
            ID: self.ID,
            Title: self.Title,
            Color: self.Color,
            TermExposure: self.TermExposure,
            Fortress: self.Fortress,
            Price: self.Price
        };

        self.WineListKO = ko.observable([]);

        self.Message = ko.observable("");
        
        loadInformation();

        function loadInformation() {

            $.ajax({
                url: "/api/WineListKOApi",
                type: "GET"
            }).done(function (resp) {
                self.WineListKO(resp);
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }

        self.getSelected = function (per) {
            self.ID(per.ID);
            self.Title(per.Title);
            self.Color(per.Color);
            self.TermExposure(per.TermExposure);
            self.Fortress(per.Fortress);
            self.Price(per.Price);
            IsUpdatable = true;
            $("#modalbox").modal("show");
        }

        self.save = function () {
            if (!IsUpdatable) {

                $.ajax({
                    url: "/api/WineListKOApi",
                    type: "POST",
                    data: WineInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    self.ID(resp.ID);
                    $("#modalbox").modal("hide");
                    loadInformation();
                }).error(function (err) {
                    self.Message("Error! " + err.status);
                });
            } else {
                $.ajax({
                    url: "/api/WineListKOApi/" + self.ID(),
                    type: "PUT",
                    data: WineInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    $("#modalbox").modal("hide");
                    loadInformation();
                    IsUpdatable = false;
                }).error(function (err) {
                    self.Message("Error! " + err.status);
                    IsUpdatable = false;
                });
            }
        }

        self.delete = function (per) {
            $.ajax({
                url: "/api/WineListKOApi/" + per.ID,
                type: "DELETE",
            }).done(function (resp) {
                loadInformation();
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }
    };
    ko.applyBindings(new viewModel());
})();