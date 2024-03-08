# Thought Process
- The webpage need to login every time user want to access service, so Login should be part of the setup that get called every time a new test is started.
- For creating project:
	- it needs a name and a id, which can be anything. When there is no project, the dialog will pop up automatically. When there is already a project, the pop up needs to be open via "new project" tab. Need to make sure to detected it
- For creating test:
	- first we need to enter a project.
	- then if there is no test, the website will open the test creation tab automatically. If there is tests, then it need to be open manually via create test button.
	- after creating a test, a popup will ask if we want to install the extension for testing, which block our validation for creating test, so I return to last page to check that
- For deleting test:
	- we need to check if there is already an existing test. we can achieve this by calling creating test first. But that require to pass the last test first.
	- when deleting, we need to hover over a invisible option button and then click it to open the option menu.
	- after deleting, if there is no test, then there will be a new element with a image saying there is no test, if there is still more test, the height of the test list should be -52px compare to what we have earlier.

# Outcome
-  I have implemented the first two tests (aka create project and creating test). Tried to implement deleting test but don't have enough time to finished that as well as other tests. 
- Learned how to use selenium during the run, and now have a light grasp of the idea of automation testing.