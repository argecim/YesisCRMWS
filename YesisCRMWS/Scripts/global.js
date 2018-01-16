var ShowNotificiation = function () {

    var configureToastr = function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-bottom-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }

    return {
        init: function () {
            configureToastr();
        },
        Error: function (title, message) {
            toastr.error(message, title);
        },
        Warning: function (title, message) {
            toastr.warning(message, title);
        },
        Success: function (title, message) {
            toastr.success(message, title);
        },
        Info: function (title, message) {
            toastr.info(message, title);
        }
    }

}();

jQuery(document).ready(function () {
    ShowNotificiation.init();
});