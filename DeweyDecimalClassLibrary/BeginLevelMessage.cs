using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalClassLibrary
{
    public class BeginLevelMessage
    {
        /// <summary>
        /// Stores the answer the user chooses when beginning a level
        /// </summary>
        private DialogResult dialogResult = DialogResult.No;

        /// <summary>
        /// Stores the level the user currently wants to play
        /// </summary>
        private string level;

        /// <summary>
        /// Stores the amount of times the user has played level 3
        /// </summary>
        private int amountPlayed;

        /// <summary>
        /// Stores the flag value for if the user has completed level 3 or not
        /// </summary>
        private bool completedLevelThree;

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="dialogresult"></param>
        public BeginLevelMessage(DialogResult DialogResult, string Level, int AmountPlayed, bool CompletedLevelThree)
        {
            dialogResult = DialogResult;
            level = Level;
            amountPlayed = AmountPlayed;
            completedLevelThree = CompletedLevelThree;
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Displays the message to the user when they want to begin a level
        /// </summary>
        public DialogResult DisplayMessage()
        {
            if (level == "levelOne")
            {
                dialogResult = MessageBox.Show("Do you wish to proceed to level 1?\n" +
                                               "Please make sure you have read and understood the instructions before continuing",
                                               "Confirmation", MessageBoxButtons.YesNo);
            }
            else if (level == "levelTwo")
            {
                dialogResult = MessageBox.Show("Do you wish to proceed to level 2?\n" +
                                               "Please make sure you have read and understood the instructions before continuing",
                                               "Confirmation", MessageBoxButtons.YesNo);
            }
            else if (level == "levelThree")
            {
                if (completedLevelThree)
                {
                    dialogResult = MessageBox.Show("I thought I said that you are free now? But it seems like you are back for more. Do you want to try again?",
                    "Are you sure you want to do this again?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 0)
                {
                    dialogResult = MessageBox.Show("Do you wish to proceed to level 3?\n" +
                    "Prepare for the ultimate challenge as you enter the heart-pounding, nerve-wracking final level of the game. " +
                    "This level is the stuff of legends, a true test of your lightning-fast wit and memory. With a mere 5 seconds on the " +
                    "clock, it has brought even the bravest souls to their knees, making grown men shed tears of frustration. It's a " +
                    "level so intense, it's whispered about in hushed tones. Brace yourself, for this level is feared by death itself, " +
                    "and it will push you to the very limits of your abilities. Will you conquer it or crumble under the pressure?" +
                    "Are you 100% sure you want to do this?",
                    "Are you sure you want to do this?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 1)
                {
                    dialogResult = MessageBox.Show("Did none of my writing from the first time scare you? Do you have a heart made of " +
                    "stone or something? Listen to me, this level is impossible, turn back now while you have the chance and go live your " +
                    "life. Trust me, it's better that way.\nDo you still want to attempt this?", "You're back?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 2)
                {
                    dialogResult = MessageBox.Show("I don't want to hurt your feelings, but seriously, why are you still attempting this? " +
                    "You may sit here for hours and hours on end attempting this, it doesn't matter to me what you do with your time. Just don't " +
                    "say that I didn't warn you though okay. Are you really really really sure you want to try again?", "You're back again?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 3)
                {
                    dialogResult = MessageBox.Show("I am really starting to like you, you got fight, but listen to me, fight is not enough to beat this " +
                    "level. Please, I am begging you to close the application and go spend time with your family. It's not worth it. Are you going to " +
                    "spend time with your family while you still can? Probably not. Alright, do you want to try again?", "I do not believe it", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 4)
                {
                    dialogResult = MessageBox.Show("Take a look at yourself in the mirror and ask yourself if this is who you want to be? Don't you see? " +
                    "There is a whole world out there to explore, but you are here trying to beat the impossible level. Please, I beg of you, exit this " +
                    "level and learn the dewey decimal system on the easier levels, do you really want to try this again?", "Please listen to me", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 5)
                {
                    dialogResult = MessageBox.Show("Oh, it's you again. I thought I'd never see you back here after try number 4. " +
                    "You've got some real dedication, but this level, my friend, is reserved for the truly insane. Are you absolutely sure " +
                    "you want to give it another shot?", "Back for More?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 6)
                {
                    dialogResult = MessageBox.Show("You know, I've seen people try this level before. Most of them end up questioning their life choices. " +
                    "Some people have sent me horrible emails explaining how this application has ruined their lives. They couldn't pay their debts " +
                    "because they were not working, they were too busy with this level. Do you want to join those people and carry on with this level?", "Ready for the Insanity?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 7)
                {
                    dialogResult = MessageBox.Show("Wow, I admire your persistence, and how none of these messages are scaring you. You may think that " +
                    "this is all a joke, but trust me friend, there is a reason why I am displaying all these messages to you. I have seen what this game " +
                    "has done to people, I do not want the same to happen to you. Are you sure you want to try again?", "Courage or Madness?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 8)
                {
                    dialogResult = MessageBox.Show("It's you again! I've run out of ways to convince you to stop, but seriously, this level " +
                    "will haunt your nightmares. Are you really, truly, 100% ready to face it?", "Unstoppable Determination?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed == 9)
                {
                    dialogResult = MessageBox.Show("Okay, this is officially crazy! Are you absolutely, positively certain you want to proceed? " +
                    "The road ahead is treacherous, and very few emerge unscathed.", "No Turning Back?", MessageBoxButtons.YesNo);
                }
                else if (amountPlayed >= 10)
                {
                    dialogResult = MessageBox.Show("Okay, I give up, goodluck. You want to try again?", "Goodluck", MessageBoxButtons.YesNo);
                }
            }
            return dialogResult;
        }
    }
}
