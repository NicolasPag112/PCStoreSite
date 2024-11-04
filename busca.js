$(document).ready(function(){

    $('#search').on('input', function() {

        const inputText = $(this).val().trim();

        if (inputText === '') {
            $('#searchResult').hide();
        } else {
            $('#searchResult').text(`Nenhum produto com '${inputText}' encontrado`).show();
        }
    });

});