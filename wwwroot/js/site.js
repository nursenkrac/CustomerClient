
const panelDiv = document.getElementById("panel");
var i = 1;
var yeniGroup;

function createsMail() {

    var yeniMail;


    yeniGroup = document.createElement("div");
    yeniGroup.setAttribute('class', 'input-group mb-2');
    yeniGroup.setAttribute('name', 'yeniGroup');
    yeniGroup.setAttribute('id', i);

    yeniMail = document.createElement("input");
    yeniMail.setAttribute('class', 'form-control');
    yeniMail.setAttribute('type', 'email');
    yeniMail.setAttribute('placeholder', 'Lütfen geçerli bir mail adresi giriniz!');
    yeniMail.setAttribute('name', 'transfer_Userss[' + i + '].mail')

    var silButton = document.createElement('button');
    silButton.setAttribute('class', 'btn btn-danger btn-group');
    silButton.innerHTML = '<i class="ion-ios-trash"></i>';
    silButton.setAttribute('type', 'button');
    silButton.setAttribute('id', i);
    silButton.setAttribute('onclick', 'removeMail(this.id)');

    yeniGroup.appendChild(yeniMail);
    yeniGroup.appendChild(silButton);

    panelDiv.appendChild(yeniGroup);



    i++;
}

function removeMail(clicked_id) {
    var e = document.getElementById(clicked_id);
    panelDiv.removeChild(e);
}

function mailOnayGonder() {
    const panelOnay = document.getElementById("verification");
    panelOnay.removeAttribute('class', 'd-none');
    panelOnay.setAttribute('style', 'transition:2s');
    gonder.setAttribute('class', 'd-none')
}

/* Verification Code START */
const inputElements = [...document.querySelectorAll('input.code-input')]

inputElements.forEach((ele, index) => {
    ele.addEventListener('keydown', (e) => {
        // if the keycode is backspace & the current field is empty
        // focus the input before the current. Then the event happens
        // which will clear the "before" input box.
        if (e.keyCode === 8 && e.target.value === '') inputElements[Math.max(0, index - 1)].focus()
    })
    ele.addEventListener('input', (e) => {
        // take the first character of the input
        // this actually breaks if you input an emoji like 👨‍👩‍👧‍👦....
        // but I'm willing to overlook insane security code practices.
        const [first, ...rest] = e.target.value
        e.target.value = first ?? '' // first will be undefined when backspace was entered, so set the input to ""
        const lastInputBox = index === inputElements.length - 1
        const didInsertContent = first !== undefined
        if (didInsertContent && !lastInputBox) {
            // continue to input the rest of the string
            inputElements[index + 1].focus()
            inputElements[index + 1].value = rest.join('')
            inputElements[index + 1].dispatchEvent(new Event('input'))
        }
    })
})


// mini example on how to pull the data on submit of the form
function onSubmit(e) {
    e.preventDefault()
    const code = inputElements.map(({ value }) => value).join('')
    console.log(code)
}

/* Dosya Seç START */


/* Dosya Seç END */


/* Verification Code END */

//const tagContainer = document.querySelector('.tag-container');
//const input = document.querySelector('.tag-container input');

//var tags = [];

//function createTag(label) {
//    const div = document.createElement('div');
//    div.setAttribute('class', 'tag');
//    const span = document.createElement('span');
//    span.innerHTML = label;
//    const closeBtn  = document.createElement('i');
//    closeBtn.setAttribute('class', 'material-icons');
//    closeBtn.setAttribute('data-item',label);
//    closebtn.innerHTML = "close";

//    div.appendChild(span);
//    div.appendChild(closeBtn);
//    return div;
//}

//function reset() {
//    document.querySelectorAll('.tag').forEach(function (tag) {
//        tag.parentElement.removeChild(tag);
//    })
//}

//function addTags() {
//    reset();
//    tags.slice().reverse().forEach(function (tag) {
//        const tag = createTag(tag);
//        tagContainer.prepend(input);
//    })
//}

//input.addEventListener('keyup', function (e) {
//    if (e.key==';') {
//        tags.push(input.value);
//        addTags();
//        input.value = '';
//    }
//})

//document.addEventListener('click', function (e) {
//    if (e.target.tagName == 'I') {

//    }
//})


/*Verification Code Start*/

const formss = document.querySelector('#verificationCode')
const inputs = formss.querySelectorAll('input')
const KEYBOARDS = {
    backspace: 8,
    arrowLeft: 37,
    arrowRight: 39,
}

function handleInput(e) {
    const input = e.target
    const nextInput = input.nextElementSibling
    if (nextInput && input.value) {
        nextInput.focus()
        if (nextInput.value) {
            nextInput.select()
        }
    }
}

function handlePaste(e) {
    e.preventDefault()
    const paste = e.clipboardData.getData('text')
    inputs.forEach((input, i) => {
        input.value = paste[i] || ''
    })
}

function handleBackspace(e) {
    const input = e.target
    if (input.value) {
        input.value = ''
        return
    }

    input.previousElementSibling.focus()
}

function handleArrowLeft(e) {
    const previousInput = e.target.previousElementSibling
    if (!previousInput) return
    previousInput.focus()
}

function handleArrowRight(e) {
    const nextInput = e.target.nextElementSibling
    if (!nextInput) return
    nextInput.focus()
}

formss.addEventListener('input', handleInput)
inputs[0].addEventListener('paste', handlePaste)

inputs.forEach(input => {
    input.addEventListener('focus', e => {
        setTimeout(() => {
            e.target.select()
        }, 0)
    })

    input.addEventListener('keydown', e => {
        switch (e.keyCode) {
            case KEYBOARDS.backspace:
                handleBackspace(e)
                break
            case KEYBOARDS.arrowLeft:
                handleArrowLeft(e)
                break
            case KEYBOARDS.arrowRight:
                handleArrowRight(e)
                break
            default:
        }
    })
})

/*Verification Code End*/

