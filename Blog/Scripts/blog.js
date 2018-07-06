$('#confirm-delete').on('click', '.btn-ok', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var id = $(this).data('recordId');
   
    $.ajax({
        type: "POST",
        url: "/Home/DeletePost",
        data: { "id": id },
        success: function () {
            $modalDiv.modal('hide');
            document.location.reload(true);
        },
        dataType: "json"
    }).then(function () {
        $modalDiv.modal('hide');
    });

});
$('#confirm-delete').on('show.bs.modal', function (e) {
    var data = $(e.relatedTarget).data();
    $('.title', this).text(data.recordTitle);
    $('.btn-ok', this).data('recordId', data.recordId);
});