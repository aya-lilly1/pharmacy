$(document).ready(function () {

    function showUploadForm() {
        console.log("done");
        $('#uploadFormModal').modal('show');


    }

    function uploadExcelFile() {
        var form = document.getElementById("excelUploadForm");
        var formData = new FormData(form);
        console.log("done1");
        $.ajax({

            url: '/admin/ImportExcelFilePharmacies',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (result) {

                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: result.message
                });
            },
            error: function (xhr, status, error) {

                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: xhr.responseJSON.error
                });
            }

        });
        console.log("done2");
        $('#uploadFormModal').modal('hide');
    }

    function showUploadFormDurgs() {
        console.log("done");
        $('#uploadDurgsFormModal').modal('show');


    }
    function uploadDurgsExcelFile() {
        var form = document.getElementById("DurgsExcelUploadForm");
        var formData = new FormData(form);
        console.log("done1");
        $.ajax({

            url: '/admin/ImportExcelFileDurgs',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (result) {

                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: result.message
                });
            },
            error: function (xhr, status, error) {

                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: xhr.responseJSON.error
                });
            }

        });
        console.log("done2");
        $('#uploadDurgsFormModal').modal('hide');
    }


});
