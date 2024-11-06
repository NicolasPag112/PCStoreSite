$(document).ready(function(){

    $('#search').on('input', function() {

        const inputText = $(this).val().trim();

        if (inputText === '') {
            $('#searchResult').hide();
        } else {
            $('#searchResult').text(`Nenhum produto com '${inputText}' encontrado`).show();
        }
    });

    $('#minPrice').on('input', function() {

        const minValue = $('#minPrice').val();
        const maxValue = $('#maxPrice').val();

        if(parseInt(maxValue) < parseInt(minValue)){
            $('#minValue').text("Erro: valor mínimo precisa ser menor que valor máximo");
            $('#maxValue').text("Erro: valor máximo precisa ser maior que valor mínimo");
        } else {
            $('#minValue').text("A partir de R$" + minValue);
        }

        

    });
    $('#maxPrice').on('input', function() {

        const minValue = $('#minPrice').val();
        const maxValue = $('#maxPrice').val();

        if(parseInt(maxValue) < parseInt(minValue)){
            $('#minValue').text("Erro: valor mínimo precisa ser menor que valor máximo");
            $('#maxValue').text("Erro: valor máximo precisa ser maior que valor mínimo");
        } else {
            $('#maxValue').text("Até R$" + maxValue);
        }

        

    });

    $('.productType').on('change', function() {
        if ($(this).is(':checked')) {
            $('.productType').not(this).prop('checked', false);
        }

        if ($('#CPU').is(':checked')) {
            $('#CPUBrands').show();
        } else {
            $('#CPUBrands').hide();

            $('.CPUBrandType').prop('checked', false);
            $('.CPUModel').prop('checked', false);

            $('#IntelModels').hide();
            $('#AMDModelsCPU').hide();
        }

        if ($('#GPU').is(':checked')) {
            $('#GPUBrands').show();
        } else {
            $('#GPUBrands').hide();

            $('.GPUBrandType').prop('checked', false);
            $('.GPUModel').prop('checked', false);

            $('#NvidiaModels').hide();
            $('#AMDModelsGPU').hide();
        }

    });

    $('.CPUBrandType').on('change', function() {
        if ($(this).is(':checked')) {
            $('.CPUBrandType').not(this).prop('checked', false);
        }

        if ($('#intel').is(':checked')) {
            $('#IntelModels').show();
        } else {
            $('#IntelModels').hide();
        }

        if ($('#AMDCPU').is(':checked')) {
            $('#AMDModelsCPU').show();
        } else {
            $('#AMDModelsCPU').hide();
        }
    });

    $('.CPUModel').on('change', function() {
        if ($(this).is(':checked')) {
            $('.CPUModel').not(this).prop('checked', false);
        }
    })

    $('.GPUBrandType').on('change', function() {
        if ($(this).is(':checked')) {
            $('.GPUBrandType').not(this).prop('checked', false);
        }

        if ($('#Nvidia').is(':checked')) {
            $('#NvidiaModels').show();
        } else {
            $('#NvidiaModels').hide();
        }

        if ($('#AMDGPU').is(':checked')) {
            $('#AMDModelsGPU').show();
        } else {
            $('#AMDModelsGPU').hide();
        }
    });

    $('.GPUModel').on('change', function() {
        if ($(this).is(':checked')) {
            $('.GPUModel').not(this).prop('checked', false);
        }
    })

});