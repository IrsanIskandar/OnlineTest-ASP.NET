"use strict";

function InsertDataAnswer() {
    var addUserAnswer = {};
    addUserAnswer.AnswersOne = $('#Answer1TD').val();
    addUserAnswer.AnswersTwo = $('#Answer2TD').val();
    addUserAnswer.AnswersThree = $('#Answer3TD').val();
    addUserAnswer.AnswersFourth = $('#Answer4TD').val();
    addUserAnswer.AnswersFive = $('#Answer1TGI').val();
    addUserAnswer.AnswersSix = $('#Answer2TGI').val();
    addUserAnswer.AnswersSeven = $('#Answer3TGI').val();
    addUserAnswer.AnswersEight = $('#Answer4TGI').val();
    addUserAnswer.AnswersNine = $('#Answer5TGI').val();
    addUserAnswer.Usr_InterviewID = $('#hidUserID').val();

    OnlineUserInterview.OnlineTestService.SaveAnswerServiceAsync(addUserAnswer, SuccessInsert);
}

function SuccessInsert(data) {
    if (data.d != null) {
        alert("Successfully Save Data. \nGood Luck");
        window.location = "Congratulation.aspx";
    }
    else {
        alert("Successfully Save Data. \nGood Luck");
    }
}