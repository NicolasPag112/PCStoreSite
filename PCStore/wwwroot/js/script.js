<script>

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