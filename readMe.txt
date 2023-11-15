Dewey Decimal Classification System Application
Description:
The aim of this project is to develop a software application for a local library that facilitates the training of library users and novice librarians in the utilization
of the Dewey Decimal Classification system. The Dewey Decimal System serves as the fundamental organizational framework within the library, categorizing knowledge into 
various subject areas. However, the challenge arises in making the learning process engaging, especially for novice librarians who may find the details of the system 
less than captivating. The objective of this software application is to transform the "often-dry" process of learning about the Dewey Decimal Classification system 
into an enjoyable and engaging experience.

Below is a description of all the forms within the application (Currently):

*** Home Form ***
The application starts off in the home form. The user will be presented with three options of games to choose from, but for now, the user only has access to one game.
The three options on the home form are as follows:
- Replace Books game
- Identify Areas
- Find Call Numbers (Coming soon)
The user can only click on the Replace Books game button as it is the only game that has been developed so far. Once clicked, the user will be taken to the Replace Books game

************************************ REPLACE BOOKS GAME ************************************

*** Replace Books Form ***
The replace books form is the form where the user plays the replace books game. Once the generate button is clicked, the user is able to drag books from the top panel to 
the bottom panel with the goal of sorting the books by their call numbers (ascending order, left panel to right panel). Once sorted correctly, the game will stop and
congratulate the user. Throughout the sorting process, a progress bar is visible which will show the progress the user has made while sorting the books. If the user has sorted
five out of the ten books correctly, the progress bar will be 50% filled. Other than the game, there are buttons that the user can click while on the Replace Books form. The
buttons are as follows:
- Generate: Resets the books back to their original position and generates a new random call number for each book (Starts the timer).
- Reset: Resets the books back to their original positions but keeps the same call numbers on each book (Timer keeps running/ticking).
- Sort: Sorts the books automatically in their respective panels (Stops the timer).
- Main Menu: Takes the user back to the Home form (also known as main menu)
- Instructions: Takes the user to the Replace Books Instructions form which explains the game to the user.
One other feature on the form in the timer checkbox. The user has an option to time themselves when sorting the books. If the timer is on, the time taken to sort the books
is displayed to the user once the game is complete.

*** Replace Books Instructions Form ***
This form is just to inform the user on how to play the game. It gives out the instructions for the user to read and provides a continue button once the user is finished
reading. Four basic instructions are given to help the user get a hang of the application quicker rather than just going in blind.

************************************ MATCH COLUMNS GAME ************************************

*** Match Columns Form ***
This is the from which displays the match-the-columns game. The user is presented with 4 boxes on the left and 7 on the right. They have to correctly match the call numbers to
their descriptions (or vice versa) and then click the check button once they have finished. The gamification process for this part is the levels. The user has 4 level options:
- Casual
- Level 1 (20 seconds)
- Level 2 (10 seconds)
- Level 3 (5 seconds)
If the user choose a level, a countdown will start and then the timer will be begin. The buttons are the same as the Replace Books form, just swapping the "sort" button for an
"auto-match" button which shows the answers. The user can also view the instructions form from here.

*** Identify Areas Instructions Form ***
This instructions form just gives the user a short breakdown of the game, and how the game works. It helps them to get started easily rather than opening the game and not knowing
what anything does. This helps the application become more usable and user-friendly.

*** Dewey Decimal System Photo Form ***
This form just shows a photo to the user on what each call numbers description is. Instead of looking it up on the internet, this just helps them as they can study it before
playing the game to fully grasp the concept of the dewey decimal system.

********************************* FINDING CALL NUMBERS GAME ************************************



That is the complete description of the application.

-----------------------------------------------------------------------------------------

How to INSTALL and RUN the application:
The application needed to run this project:
- Visual Studio (Any version that can run C#)
(The application used to make this project was Visual Studio 2022 version)

Open up visual studio and click on "Open project or solution"

Find the folder that this application is stored in and open the folder. Click on the application inside and then it will direct you to the 
application in visual studio. Once the application has finished loading and you can see the solution explorer for the project, click the "run application" button to
start the application (next to the green arrow on the top of visual studio HUD).

Once running, the application will start compiling. You will then be taken to the home form of the application.

!!!!!!!!!!!!!IMPORTANT!!!!!!!!!!!!!!!!
Upon opening the application, if you get an error that shows:
"Couldnt process file due to its being on the internet or restricted zone or having the mark of the web on the file. Remove the mark of the web if you want to process these files."
This error may occur if you run the application in another version that is not Visual Studio 2022.
This is an exact step by step guide on what to do:
1 - Navigate to the file where the project is stored
2 - Open up the "PROG7311_POE_PART_1" folder
3 - Find all the files that end in .resx
4 - Right click on all the files 1 by 1 and find and tick the "Unblock" check box/button.
5 - Once all .resx files have been unblocked, rebuild the application in visual studios
6 - Run the application (Everything should be fixed now)

--------------------------------------------------------------------------------------------------------------------------------------------

Personal opinion for PART 1:
This was a very fun and challenging application to create. I did all of the designs for the application myself, along with 99% of the code (other 1% was referenced).
The most challenging part was learning about some of the events that I have never learned about before, like DragDrop, MouseEnter etc. After a lot of reading and researching,
I managed to get the jist of it, and from there, I started flying through all the code. At the end of the day, I am very proud of this application. It took a lot of hours and
blood, sweat and tears, but I managed to code and design an application that I am very happy with. It was a good experience thinking out the box and figuring out how I am
going to make this application fun and engaging.

--------------------------------------------------------------------------------------------------------------------------------------------

Personal opinion for PART 2
Let me start off by saying that this application was much more difficult for me in terms of designing and creating the application than part 1. The designs took me much longer,
along with all the source code. I now implemented user controls into my application, but it was tough using it all on one form because I already had made other forms without
user controls, but for my next big project, I am going to be using user controls to its full capacity. Other than that, it was still a very fun application to make, and I am
proud of what I did in the little time I had. I really think this application looks good, and I am excited for the final part. Overall, I do think this part 2 is also fun and
engaging, especially because of what I did with level 3. Goodluck!

--------------------------------------------------------------------------------------------------------------------------------------------