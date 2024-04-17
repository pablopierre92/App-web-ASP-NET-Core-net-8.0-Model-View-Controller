﻿

$(document).ready(function () {

    $('#Emprestimos').DataTable({
        language:
        {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Mostrando _START_ registro de _END_ em um total de _TOTAL_ entries",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }
    });


    setTimeout(function () {     //fechar a div alert em 5000 milisegundos

        $(".alert").fadeOut("slow", function () {
            $(this).alert('close')
        })

    }, 5000)

})