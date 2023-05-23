var TaskCounter = 0;

var Button = $('#AddTaskButton');

Button.click(() => {

    var Options = $("#Options").val();
    if (Options == 3) {
        CreateFullAnswer();
    }
    else if (Options == 1) {
        CreateRadioBoxes();
    }
    else {
        CreateCheckBoxes();
    }
    TaskCounter++;
});

function CreateFullAnswer() {
    var FullAnswer = $('<input>', {
        name: 'Tasks[' + TaskCounter + '].Question',
        type: 'text',
        placeholder: "Введіть запитання",
        class: 'MyInput'
    });
    var hidenCorrectAnser = $('<input>', {
        name: 'CorrectAnswer[' + TaskCounter + ']',
        type: 'hidden',
        value: null
    });
    var hidenAnswerType= $('<input>', {
        name: 'Tasks['+TaskCounter +'].Type' ,
        type: 'hidden',
        value: 2
    });


    var hidenAnswerTypeHTML = hidenAnswerType.prop('outerHTML');
    var fullAnswerHTML = FullAnswer.prop('outerHTML');
    var hidenCorrectAnserHTML = hidenCorrectAnser.prop('outerHTML');
    $('#Reflection').append('<div class="AnswerPlace"><h4 style="margin-left: 4px;">Повна відповідь:</h4>' + fullAnswerHTML + hidenCorrectAnserHTML + hidenAnswerTypeHTML+ '</div>');
}

function CreateRadioBoxes() {
    var AnswerPlace = $('<div>', {
        class: 'AnswerPlace'
    });

    var AddOneButton = $('<input>', {
        type: 'button',
        class: 'MyButton',
        style: 'width: 98.5%; margin-top: 30px;',
        value: 'Додати варіант відповіді'
    });
    var hidenAnswerType = $('<input>', {
        name: 'Tasks[' + TaskCounter + '].Type',
        type: 'hidden',
        value: 1
    });

    var counter = TaskCounter;
    var optionCounter = 0; // Лічильник опцій для поточного AnswerPlace

    AddOneButton.click(function () {
        var optionName = 'Tasks[' + counter + '].options[' + optionCounter + ']';

        var optionInput = $('<input>', {
            type: 'text',
            name: optionName,
            class: 'MyInput',
            style: 'width: 97%; margin-top: 35px;',
            placeholder: 'Введіть варіант відповіді'
        });

        var checkbox = $('<input>', {
            type: 'radio',
            name: 'CorrectAnswer[' + counter + ']',
            value: optionCounter,
            required: true
        });

        var label = $('<label>').append(optionInput).append(checkbox);

        $(this).before(label);

        optionCounter++; // Збільшення лічильника опцій після додавання нового поля вводу
    });

    var FullAnswer = $('<input>', {
        name: 'Tasks[' + TaskCounter + '].Question',
        type: 'text',
        placeholder: 'Введіть запитання',
        class: 'MyInput',
        required: true
    });

    AnswerPlace.append('<h4 style="margin-left: 4px;">Одна вірна відповідь:</h4>');
    AnswerPlace.append(FullAnswer);
    AnswerPlace.append(AddOneButton);
    AnswerPlace.append(hidenAnswerType);

    $('#Reflection').append(AnswerPlace);
}

function CreateCheckBoxes() {
    var AnswerPlace = $('<div>', {
        class: 'AnswerPlace'
    });

    var AddOneButton = $('<input>', {
        type: 'button',
        class: 'MyButton',
        style: 'width: 97%; margin-top: 30px;',
        value: 'Додати варіант відповіді'
    });
    var hidenAnswerType = $('<input>', {
        name: 'Tasks[' + TaskCounter + '].Type',
        type: 'hidden',
        value: 0
    });

    var counter = TaskCounter;
    var optionCounter = 0; // Лічильник опцій для поточного AnswerPlace

    AddOneButton.click(function () {
        var optionName = 'Tasks[' + counter + '].options[' + optionCounter + ']';

        var optionInput = $('<input>', {
            type: 'text',
            name: optionName,
            class: 'MyInput',
            style: 'width: 97%; margin-top: 35px;',
            placeholder: 'Введіть варіант відповіді',
        });

        var checkbox = $('<input>', {
            type: 'checkbox',
            name: 'CorrectAnswer[' + counter + ']',
            value: optionCounter
        });

        var label = $('<label>').append(optionInput).append(checkbox);

        $(this).before(label);

        optionCounter++; // Збільшення лічильника опцій після додавання нового поля вводу
    });

    var FullAnswer = $('<input>', {
        name: 'Tasks[' + TaskCounter + '].Question',
        type: 'text',
        placeholder: 'Введіть запитання',
        class: 'MyInput',
        required: true
    });

    AnswerPlace.append('<h4 style="margin-left: 4px;">Одна вірна відповідь:</h4>');
    AnswerPlace.append(FullAnswer);
    AnswerPlace.append(AddOneButton);
    AnswerPlace.append(hidenAnswerType);

    $('#Reflection').append(AnswerPlace);
}
