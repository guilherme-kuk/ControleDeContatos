$(function () {
    setTimeout(function () {
        $(".alert").hide();
    }, 3000);

    $('.table-data-table').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "scrollX": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado.",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado.",
            "sSearch": "Pesquisar",
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            },
        }
    });
})

$(".btn-total-contatos").on("click", function () {
    let usuarioId = $(this).attr("usuario-id");

    $.ajax({
        type: "GET",
        url: "/Usuario/ListarContatosPorUsuarioId/" + usuarioId,
        success: function (result) {
            $("#listaContatosUsuarios").html(result);
            $("#modalContatosUsuario").modal("toggle");
        }
    });
})