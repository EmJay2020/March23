$(() => {
    $("input").on('keyup', function () {
        valid();        
    }
        )
    function isFilled() {
        const Model = $("#Model").val();
        const Make = $("#Make").val();
        const Year = $("#Year").val();
        const Price = $("#Price").val();
        return Model && Make && Year && Price ;
    }
    function valid() {
        $("#btn").prop('disabled', !isFilled());
    }

    $('#CarType').on('change', function () {
          
        if ($(this).val() == 2) {
            $('#IsLeather').prop('checked', true);
            $('#IsLeather').prop('disabled', true);
            $("#My-Form").append("<input type='hidden' name=IsLeather id='hidden' value=true");
        }
        else {
            $('#IsLeather').prop('disabled', false);
            $('#hidden').remove();
        }
    })
})