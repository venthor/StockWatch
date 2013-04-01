; (function (ns, window, document, undefined) {

    ns.clients = (function () {

        return {
            init: function () {
                console.log("stocks.init");
                $('#Stock_Name').focus();
            },

            show: function () {
                console.log("stocks.show");
            }
        };

    })();

})(Structure, window, document);