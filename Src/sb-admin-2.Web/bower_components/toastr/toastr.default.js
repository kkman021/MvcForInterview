toastr.options = {
    closeButton: true,
    progressBar: true,
    showMethod: 'slideDown',
    timeOut: 4000
};

function displayToastrMessage(type, message, title) {
    window.toastr[type](message, title);
}