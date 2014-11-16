Feature: ImageGallery
	In order to view all the available images in the gallery for a category
	As a site User
	I want be shown a page of images for that category

@mytag
Scenario: Display Most Recent Images On Initial Page Load
	Given I have selected the Photography page 
	And I have not filtered the selection
	When I enter the page
	Then the 12 most recent images for photographs should be displayed
	
Scenario: Display Only Images From The Correct Category
	Given I have selected the Photography page
	When I an on this page
	Then only images in the Photography category should be displayed

Scenario: Enable Paging To Allow The Displaying Of Additional Available Images 
	Given there are more than 12 images available based on the current selection
	When the image gallery is displayed
	Then a paging option is available to page through all available images

Scenario: Display Filters For The Avaliable Year Groups
	Given there are available images
	When images are displayed
	Then filters for the Year Group that took the various images will be displayed

Scenario: Filter The Images By Year Group
	Given that a Year Group filter is selected 
	When the images are displayed
	Then only images of the selected Year Group will be present

Scenario: Display Filters For The Avaliable Image Collection
	Given there are available images
	When images are displayed
	Then filters for the Collections that the various available images are in will be displayed

Scenario: Filter The Images By Collection
	Given that a Collection filter is selected 
	When the images are displayed
	Then only images of the selected Collection will be present

Scenario: Display LightBox When An Image Is Pressed
	Given that a user wants to view an specific image in a larger format
	When the image is selected (clicked)
	Then a lightbox will open to display the selected image in large format

Scenario: Display Next Button In The LighBox
	Given that the lightbox is being displayed
	When there is more than one image in the current collection
	And the current image isn't the last image in the collection
	Then the next button will appear in the lightbox window

Scenario: Move To The Next Image In The Collection 
	Given that the next button is displayed in the lightbox
	When the next button is clicked
	Then the next image in the collection will be displayed in the lightbox

Scenario: Display Previous Button In The LighBox
	Given that the lightbox is being displayed
	When there is more than one image in the current collection
	And the current image isn't the first image in the collection
	Then the previous button will appear in the lightbox window

Scenario: Move To The Previous Image In The Collection 
	Given that the previous button is displayed in the lightbox
	When the previous button is clicked
	Then the previous image in the collection will be displayed in the lightbox