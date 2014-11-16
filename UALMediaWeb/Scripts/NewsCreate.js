$(document).ready(function () {
    //Mark Down Editor Start
    $("textarea.mdd_editor").MarkdownDeep({
        help_location: "/Content/mdd_help.html",
        disableTabHandling: true,
        resizebar: false
    });

    //Update element content on form input change
    jQuery.fn.updateElementContentFromForm = function (inputBox, targetElement) {
        $(this).on("change", inputBox, function () {
            $(targetElement).text($(inputBox).val());
        })
    };

    var inputContainer = $("#news-article-editor");

    $(inputContainer).updateElementContentFromForm("#news-headline", ".news-headline");
    $(inputContainer).updateElementContentFromForm("#article-lead", ".article-lead");


    function readURL(input) {

        if (input.files && input.files[0]) {
            $(".news-main-image").html('<img src="no-image-available.jpg"/>');
            var reader = new FileReader();

            reader.onload = function (e) {
                $('.news-main-image img').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#news-main-image").change(function () {
        readURL(this);
    });


    skrollr.init({
        smoothScrolling: false,
        mobileDeceleration: 0.004,
        forceHeight: true
    });
});