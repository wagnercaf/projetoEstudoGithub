$('.btnDelete').click(function () {
    var Id = $(this).attr('data-id');
    var Url = "/Cursos/ExcluirCurso?Id=" + Id;
    //alert(Url);
    if (confirm("Realmente deseja excluir este curso?")) {
        $.ajax({
            type: 'Delete',
            url: Url,
            success: function (result) {
                alert("Curso Excluido com sucesso!")
                window.location.href = "/Cursos/ListaCursos";

            }
        });
    }
});

$('.btnDetalhes').click(function () {
    var Id = $(this).attr('data-id');
    var Url = "/Cursos/Detalhe?Id=" + Id;
    $('#modal').load(
        Url,
        function () {
            $('#modal').modal('show');
        });

});

$('.btnUpdate').click(function () {
    var Id = $(this).attr('data-id');
    var Url = "/Cursos/Alterar?Id=" + Id;
    $('#modal').load(
        Url,
        function () {
            $('#modal').modal('show');
        });

});