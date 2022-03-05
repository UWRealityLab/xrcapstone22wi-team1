using System;
public static class Message
{
    public const string WELCOME_MESSAGE = "Welcome to the CSE advising center. I'm your advisor Anna.";
    public const string ASK_ROLE = "Are you a high school student or a transfer student?";
    public const string ASK_TOPIC = "What questions or concerns do you have for me?";

    // High School Student
    public const string HIGH_SCHOOL_INTRO = "Thank you for your interest in the Paul G. Allen School of Computer Science & Engineering. You will be considered for Direct To Major admission in the Allen School if you select Computer Science or Computer Engineering as the first-choice major on your application.";

    public const string HS_Q_ADMIN_RATE = "What is the admission rate for the Allen School?";
    public const string HS_A_ADMIN_RATE = "In 2021,\n1732 WA residents applied and 456 were admitted (26.3%).\n3887 Domestic Non-Resident applied and 99 were admitted (2.5%).\n1117 internationl students applied and 43 were applied (3.84%).";
    public const string HS_Q_PROGRAM_EXP = "Do I need to have programming experience in high school?";
    public const string HS_A_PROGRAM_EXP = "No, we do not expect freshman applicants to have any programming experience. We look for those students who demonstrate academic excellence and leadership.";
    public const string HS_Q_GPA = "Is there a minimum GPA to be competitive for admission?";
    public const string HS_A_GPA = "The Office of Admissions uses a holistic review process to make DTM decisions. Most students offered DTM have a high school GPA of 3.85-4.00 (unweighted).";

    // Transfer Student
    public const string TRANSFER_INTRO = "Thank you for your interest in the Paul G. Allen School of Computer Science & Engineering.";
    public const string TF_Q_GPA = "Is there a minimum GPA to be competitive for admission?";
    public const string TF_A_GPA = "No. Due to the Allen School’s holistic admissions review process, there is no minimum GPA required for admission.\nThe average incoming GPA for Washington state resident transfer admits is 3.75 or higher.\nThe average incoming GPA for domestic non-resident and international transfer admits is 3.9 or higher.";
    public const string TF_Q_APPLY = "Can I apply before I’ve completed two years at a community college or university?";
    public const string TF_A_APPLY = "Yes. If you have met UW’s minimum admissions requirements and will fulfill the Allen School’s prerequisite requirements in time, you are welcome to apply for transfer admission.";
    public const string TF_Q_REAPPLY = "Can I reapply to the Allen School as a transfer applicant if I have been denied before?";
    public const string TF_A_REAPPLY = "Yes. The Allen School does not have a limit on the number of times a transfer applicant can apply for admission.";

    // Dubs 
    public const string GAME_START = "Welcome to Gates Center of the Allen School! I am Dubs, your tour guide. In this tour, please follow the line on the floor to go to your next stop.";
    public const string INTERACTIVE_WALL = "Now, on the Interactive Wall, there are four main topics that you may be interested in and you can drag the wall to view more information. Please read through the contents. We will have a quiz for you at the end of the tour.";
    public const string VIRTUAL_ADIVISING_CENTER = "Got questions for Allen School admissions? Welcome to the Advising Center! You can choose your options for freshmen admission or transfer admission.";
    public const string INTERVIEW_ROOM = "You finished the CSE2 Virtual Tour! Let’s have a pop quiz to test your knowledge for the building. If you pass the quiz, you’ll receive a badge to enter undergrad common!";
    public const string FOLLOW_PATH = "I have a couple tasks for you to complete during this tour. First of all, let’s go to the big Interactive Wall to learn more about the Allen school.";
}
