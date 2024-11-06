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
            $('#minValue').text("Erro");
            $('#maxValue').text("Erro");
            $('#errorValue').show();
        } else {
            $('#minValue').text("A partir de R$" + minValue);
            $('#maxValue').text("Até R$" + maxValue);
            $('#errorValue').hide();
        }

        

    });
    $('#maxPrice').on('input', function() {

        const minValue = $('#minPrice').val();
        const maxValue = $('#maxPrice').val();

        if(parseInt(maxValue) < parseInt(minValue)){
            $('#minValue').text("Erro");
            $('#maxValue').text("Erro");
            $('#errorValue').show();
        } else {
            $('#minValue').text("A partir de R$" + minValue);
            $('#maxValue').text("Até R$" + maxValue);
            $('#errorValue').hide();
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

        if ($('#RAM').is(':checked')) {
            $('#RAMSizes').show();
        } else {
            $('#RAMSizes').hide();

            $('.RAMSize').prop('checked', false);
        }

        if ($('#motherBoard').is(':checked')) {
            $('#MBBrands').show();
        } else {
            $('#MBBrands').hide();

            $('.MBBrand').prop('checked', false);
        }

        if ($('#SSD-HDD').is(':checked')) {
            $('#SHDSizes').show();
            $('#SHDSpeeds').show();
        } else {
            $('#SHDSizes').hide();
            $('#SHDSpeeds').hide();

            $('.SHDSize').prop('checked', false);
            $('.SHDSpeed').prop('checked', false);
        }

        if ($('#PSU').is(':checked')) {
            $('#PSUPowers').show();
        } else {
            $('#PSUPowers').hide();

            $('.PSUPower').prop('checked', false);
        }

        if ($('#monitor').is(':checked')) {
            $('#monitorSizes').show();
            $('#monitorResolutions').show();
            $('#monitorHdr').show();
        } else {
            $('#monitorSizes').hide();
            $('#monitorResolutions').hide();
            $('#monitorHdr').hide();

            $('.monitorSize').prop('checked', false);
            $('.monitorResolution').prop('checked', false);
            $('.monitorHdr').prop('checked', false);
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

    $('.RAMSize').on('change', function() {
        if ($(this).is(':checked')) {
            $('.RAMSize').not(this).prop('checked', false);
        }
    })

    $('.MBBrand').on('change', function() {
        if ($(this).is(':checked')) {
            $('.MBBrand').not(this).prop('checked', false);
        }
    })

    $('.SHDSize').on('change', function() {
        if ($(this).is(':checked')) {
            $('.SHDSize').not(this).prop('checked', false);
        }
    })

    $('.SHDSpeed').on('change', function() {
        if ($(this).is(':checked')) {
            $('.SHDSpeed').not(this).prop('checked', false);
        }
    })

    $('.PSUPower').on('change', function() {
        if ($(this).is(':checked')) {
            $('.PSUPower').not(this).prop('checked', false);
        }
    })

    $('.monitorSize').on('change', function() {
        if ($(this).is(':checked')) {
            $('.monitorSize').not(this).prop('checked', false);
        }
    })

    $('.monitorResolution').on('change', function() {
        if ($(this).is(':checked')) {
            $('.monitorResolution').not(this).prop('checked', false);
        }
    })

    $('.monitorHdr').on('change', function() {
        if ($(this).is(':checked')) {
            $('.monitorHdr').not(this).prop('checked', false);
        }
    })

});