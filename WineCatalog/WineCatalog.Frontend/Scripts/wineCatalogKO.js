(function () {
    var viewModel = function () {
        var self = this;

        var IsUpdatable = false;

        self.Id = ko.observable(0);
        self.Title = ko.observable("");
        self.Color = ko.observable("");
        self.TermExposure = ko.observable("");
        self.Fortress = ko.observable("");
        self.Price = ko.observable("");

        var WineInfo = {
            Id: self.Id,
            Title: self.Title,
            Color: self.Color,
            TermExposure: self.TermExposure,
            Fortress: self.Fortress,
            Price: self.Price
        };

        self.WineCatalogJs = ko.observable([]);

        self.Message = ko.observable("");

        loadInformation();

        function loadInformation() {

            $.ajax({
                url: "api/WineCatalogKOApi",
                type: "GET"
            }).done(function (resp) {
                self.WineCatalogJs(resp);
            }).error(function (err) {
                self.Message("Ошибка! " + err.status);
            });
        }

        self.getSelected = function (per) {
            self.Id(per.Id);
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
                    url: "api/WineCatalogKOApi",
                    type: "POST",
                    data: WineInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    self.Id(resp.Id);
                    $("#modalbox").modal("hide");
                    loadInformation();
                }).error(function (err) {
                    self.Message("Ошибка! " + err.status);
                });
            } else {
                $.ajax({
                    url: "api/WineCatalogKOApi/" + self.Id(),
                    type: "PUT",
                    data: WineInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    $("#modalbox").modal("hide");
                    loadInformation();
                    IsUpdatable = false;
                }).error(function (err) {
                    self.Message("Ошибка! " + err.status);
                    IsUpdatable = false;
                });
            }
        }

        self.delete = function (per) {
            $.ajax({
                url: "api/WineCatalogKOApi/" + per.Id,
                type: "DELETE",
            }).done(function (resp) {
                loadInformation();
            }).error(function (err) {
                self.Message("Ошибка! " + err.status);
            });
        }
    };
    ko.applyBindings(new viewModel());
})();