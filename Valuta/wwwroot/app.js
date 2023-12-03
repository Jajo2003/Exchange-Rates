const submitBtn = document.getElementById('submit-btn');

const inputAmount = document.getElementById('Amount');

const resultP = document.getElementById('result');

const UsdBox = document.getElementById('UsdBox');

const EurBox = document.getElementById('EuroBox');

UsdBox.addEventListener('click', function () {
    if (EurBox.checked = true) {
        EurBox.checked = false;
    }

});

EurBox.addEventListener('click', function () {
    if (UsdBox.checked = true) {
        UsdBox.checked = false;
    }

});




submitBtn.addEventListener('click', function () {

    const amount = inputAmount.value;
    if (UsdBox.checked === true) {
        resultP.innerHTML = amount * 3;
    }
    else if (EurBox.checked === true) {
        resultP.innerHTML = amount * 5;
    }
    else {
        resultP.innerHTML = "Choose Currency";
    }


});