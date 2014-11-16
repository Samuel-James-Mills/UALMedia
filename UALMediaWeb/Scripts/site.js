$(document).ready(function () {

    var slider = function (elementID) {

       
        //Set the different selectors
        //triggers are the differnt number list item buttons
        var triggers = $(elementID + ' ul.triggers li');
        // images are the list items containing the images
        var images = $(elementID + ' ul.images li');
        //lastElem is the length of the triggers list minus 1 (as it has 0 as the start number)
        var lastElem = triggers.length - 1;
        //mask is the unordered list the contains all the images
        var mask = $(elementID + ' .mask ul.images');
        //imgWidth gets the width of the image
        var imgWidth = images.width();
        //maskWidth is the total width of the image display mask
        var maskWidth = $(elementID + ' .mask').width();
        // percentageWidth is the percentage width of each image compared to the mask container div
        var percentageWidth = (imgWidth / maskWidth) * 100;
        //target will be used to select the image that we want
        var target;
        //Mark the first image in the list as selected when the page first loads
        triggers.first().addClass('selected');

        //takes in the current target information and then uses it and the percentage width to move the 
        //ul containing the images to the correct position. then changes the selected class to the new target and removes it form the old one
        function sliderResponse(target) {
            mask.stop(true, false).animate({ 'left': '-' + percentageWidth * target + '%' }, 500);
            triggers.removeClass('selected').eq(target).addClass('selected');
        }

        function sliderPrevButton(elementID) {
            target = $(elementID + ' ul.triggers li.selected').index();
            lastElem = triggers.length - 1;
            target === 0 ? target = lastElem : target = target - 1;
            sliderResponse(target);
        }

        function sliderNextButton(elementID) {
            target = $(elementID + ' ul.triggers li.selected').index();
            target === lastElem ? target = 0 : target = target + 1;
            sliderResponse(target);
        }

        function sliderTriggerButton(selectedTrigger) {
            if (!$(selectedTrigger).hasClass('selected')) {
                target = $(selectedTrigger).index();
                sliderResponse(target);
            }
        }
        //A click handler for the differnt number buttons in the trigger ul.  if the button clicked isn't the current selected image. 
        //then, 
        //set the target to the clicked image and  call the sliderResponse function with the new target as a parameter.
        triggers.click(function () {
            sliderTriggerButton($(this));
        });

        //A click handler for the next button.  if the button is clicked.
        //then,
        //check to see if the target is the last element if if is then reset the target to 0 else add one to the target
        $(elementID + ' .slider-next').click(function () {
            sliderNextButton(elementID);
        });

        //A click handler for the prev button.  if the button is clicked.
        //then,
        //check to see if the target is the first element if it is then reset the target to the last element else subtract one from the target
        $(elementID + ' .slider-prev').click(function () {
            sliderPrevButton(elementID);
        });

        //Button color icon change
        $(elementID + ' .slider-next').mouseover(function () {

            $(elementID + ' .slider-next span').css("color", "rgb(0,153,204)");
        });

        $(elementID + ' .slider-next').mouseout(function () {

            $(elementID + ' .slider-next span').css("color", "rgb(114,2,12)");
        });

        $(elementID + ' .slider-prev').mouseover(function () {

            $(elementID + ' .slider-prev span').css("color", "rgb(0,153,204)");
        });

        $(elementID + ' .slider-prev').mouseout(function () {

            $(elementID + ' .slider-prev span').css("color", "rgb(114,2,12)");
        });
    }

    slider('#latest');
    slider('#top-10');

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            //data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-ualm-target");
            $(target).replaceWith(data);
        });
        return false;
    };

    $(".main-content").on("click", ".pagedList a", getPage);
});
