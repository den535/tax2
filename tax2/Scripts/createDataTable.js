function CreateDataTable() {
    $("table").DataTable({
        "aLengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        bJQueryUI: true,
        sPaginationType: "full_numbers",
        "oLanguage": {
            "sProcessing": "Подождите...",
            "sLengthMenu": "Показать _MENU_ записей",
            "sZeroRecords": "Записи отсутствуют.",
            "sInfo": "Записи с _START_ до _END_ из _TOTAL_ записей",
            "sInfoEmpty": "Записи с 0 до 0 из 0 записей",
            "sInfoFiltered": "(отфильтровано из _MAX_ записей)",
            "sInfoPostFix": "",
            "sSearch": "Поиск:",
            "sUrl": "",
        }
    });
}
