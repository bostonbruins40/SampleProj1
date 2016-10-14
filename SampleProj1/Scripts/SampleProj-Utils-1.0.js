

function SendSMSMessage() {

    var fromnm = $('#SentFromName');
    var tonum = $('#SendToPhoneNumber');
    var tomsg = $('#SendToMessage');


    $.ajax({
        url: "/Home/SendSMSMessage/",
        type: "POST",
        data: {
            fromName: fromnm.val(),
            tophNumber: tonum.val(),
            toMessage: tomsg.val()
        },
        success: function (resp) {
            //clear form and modal message successful
        },
        error: function (e) {
           //pop modal with error
        }
    });
}