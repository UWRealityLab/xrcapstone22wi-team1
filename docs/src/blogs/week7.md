# Week 7 (2/21 - 2/27)

## New Features
- Added the advising center and the UI for admission FAQ.
- Added the UI for final quiz of the virtual tour.
- Adjusted pathfinding script for Dubs for better interactive experience.
- One advisor is actually at advising center.

## Files to Reviews
- [cse2VirtualTour/Assets/Scripts/Dubs/DubsNavMesh.cs](https://github.com/UWRealityLab/xrcapstone22wi-team1/blob/2ae2c0590df656510222e20a645a8dfc9a8ebda8/cse2VirtualTour/Assets/Scripts/Dubs/DubsNavMesh.cs)
- [cse2VirtualTour/Assets/Scripts/FinalQuiz/QuizManager.cs](https://github.com/UWRealityLab/xrcapstone22wi-team1/blob/develop/cse2VirtualTour/Assets/Scripts/FinalQuiz/QuizManager.cs)
- [cse2VirtualTour/Assets/Scripts/FinalQuiz/QnA.cs](https://github.com/UWRealityLab/xrcapstone22wi-team1/blob/develop/cse2VirtualTour/Assets/Scripts/FinalQuiz/QnA.cs)
- [cse2VirtualTour/Assets/Scripts/FinalQuiz/AnswerScript.cs](https://github.com/UWRealityLab/xrcapstone22wi-team1/blob/develop/cse2VirtualTour/Assets/Scripts/FinalQuiz/AnswerScript.cs)
- [cse2VirtualTour/Assets/Scripts/FinalQuiz/Restart.cs](https://github.com/UWRealityLab/xrcapstone22wi-team1/blob/develop/cse2VirtualTour/Assets/Scripts/FinalQuiz/Restart.cs)
- [cse2VirtualTour/Assets/Scripts/Advisor/Advisor.cs](https://github.com/UWRealityLab/xrcapstone22wi-team1/blob/advisor/cse2VirtualTour/Assets/Scripts/Advisor/Advisor.cs)
## Blocking Issues

- What is a good way to save a game object and all of its children's position and rotation information?

## Individual Updates

- Jolin
    - Implemented the quiz feature. There are four questions for the quiz for now. I made the `QnA` class serializable so we can add questions as more as we want without modify the script. Please check `QnA.cs` and `QuizManager.cs`.
- Justin
    - Added more Q&A to the advising center.
    - Refactored building model to different subgroups so all objects will be flat in one level.
    - Added human advisor at the advising center.
    - Added waving animation when user enter advising center.
- Peter
    - Adjust Dubs pathfinding script so the dubs does not move when player move their headset. In addition, dubs will not try to move to its desire destination when the user stop moving.