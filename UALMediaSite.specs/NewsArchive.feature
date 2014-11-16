Feature: NewsArchive
	In order read news articles
	As a User
	I want to select an article from the available articles

@mytag
Scenario: Most Recent 18 Abridged Articles Displayed By Default
	Given I have navigated to the  NewsArchive page
	When I enter the page
	Then the 18 most recent articles shoud be displayed in an abridged format

Scenario: When An Article Is Selected, The Selected Article Is Displayed On The Main News Page
	Given I am on the NewsArchive page
	When I select (click on) an article 
	Then the main News page is naigated to
	And the selected article is displayed


