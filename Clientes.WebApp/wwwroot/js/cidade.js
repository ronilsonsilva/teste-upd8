

$(document).ready(function () {
    var estadoValue = $('#Estado').val();
    if (estadoValue != '') {
        carregarCidades(estadoValue);
    }

    $('#Estado').on('change', function () {
        var estadoSelect = $(this).val();
        carregarCidades(estadoSelect);
    });

    function carregarCidades(estadoSelect) {
        $.ajax({
            url: '/Home/Cidades',
            type: 'GET',
            data: { estado: estadoSelect },
            success: function (result) {
                var codigoCidade = $("#CodigoCidade").val();
                console.log(codigoCidade);
                var selectElement = document.getElementById('CodigoCidade');
                while (selectElement.firstChild) {
                    selectElement.removeChild(selectElement.firstChild);
                }

                var optionElement = document.createElement('option');
                optionElement.value = '';
                optionElement.textContent = 'Selecione a cidade';


                for (var i = 0; i < result.length; i++) {
                    var optionElement = document.createElement('option');
                    optionElement.value = result[i].codigoIBGE;
                    optionElement.textContent = result[i].nome;
                    if (codigoCidade == result[i].codigoIBGE) {
                        optionElement.selected = true;
                    }
                    selectElement.appendChild(optionElement);
                }
            },
            error: function () {
            }
        });
    }
});