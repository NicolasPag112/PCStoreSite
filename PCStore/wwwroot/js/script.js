const URL = "http://localhost:5066/";




function AtualizaExcecao() {

    var strDados = '';

    strDados += '{';
    strDados += '"strProduto":"' + strProduto + '", ';
    strDados += '"lngCartao":"' + lngCartao + '", ';
    strDados += '"lngSequencia":"' + lngSequencia + '", ';
    strDados += '"strNovaSituacao":"' + strNovaSituacao + '" ';
    strDados += '}';

    waitingDialog.show();

    $.ajax({
        type: "POST",
        url: strCaminhoSistema + '/RegistraTransacao/AlteraSituacaoExcecao',
        data: "strProduto=" + strProduto + "&lngCartao=" + lngCartao + "&lngSequencia=" + lngSequencia + "&strNovaSituacao=" + strNovaSituacao,
        success: function (txt) {

            waitingDialog.hide();

            if (typeof txt.strMensagem != 'undefined') {
                if (txt.strMensagem != '') {
                    mostraMensagem(txt.strMensagem);
                };
            };

        },
        error: function (txt) {
            waitingDialog.hide();
            mostraMensagem(txt.strMensagem);
        }
    });

    MostraConsulta('RegistraTransacao/FilaExcecoes');
};


$(document).ready(function () {
    $(".formLogin").submit(function (event) {
        event.preventDefault(); // Cancela o recarregamento da página, em tese
        handleLogin(); // Chama a função de login ao clicar no botão
    });
});

function handleLogin() {
    //  Dados que serão enviados no corpo da requisição
    const loginData = {
        Email: $("#email").val(),
        Senha: $("#senha").val()
    };

    //Chamada ao método POST
    $.ajax({
        url: "http://localhost:5066/usuario/login",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(loginData),
        success: function (response) {
            console.log("Login bem-sucedido:", response); //Lógica para redirecionamento ou manipulação do sucesso
            alert("Login bem-sucedido!"); //Exibe uma mensagem de sucesso
        },
        error: function (error) {
            console.error("Erro no login:", error); //Lógica para lidar com erros
            alert("Erro no login. Tente novamente."); //Exibe uma mensagem de erro
        }
    });
};