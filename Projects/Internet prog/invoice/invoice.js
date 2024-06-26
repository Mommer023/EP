"use strict";
//calculate function to determine the discount percentage.
const calculateDiscount = (customer, subtotal) => {
    switch(customer) {
        case "reg":
            if (subtotal >= 100 && subtotal < 250) {
                return .1;
            } else if (subtotal >= 250 && subtotal < 500) {
                return  .25;
            } else if (subtotal >= 500) {
                return .3;
            } else {
                return 0;
            }
        case "loyal":
            return .3;
        case "honored":
            return (subtotal < 500) ? .4 : .5;
    }
};

    //function that gets the date entered and formats the entry.
    // this allows the getformattedDate resutlt to be assigned as "date" 
const getFormattedDate = date => {
    
    const now = new Date(month, day, year);


    const month = getMonth() + 1;
    const day = getDate();
    const year = getFullYear();
    const dateText = month + / + day + / + year;

    return dateText;    
}

$( document ).ready( () => {

    //event for click calculate button event
    $("#calculate").click( () => {
        //dropdown list for customer type
        const customerType = $("#type").val();
        let subtotal = $("#subtotal").val() || 0;  // default value of zero
        subtotal = parseFloat(subtotal);

        const discountPercent = calculateDiscount(customerType, subtotal);
        const discountAmount = subtotal * discountPercent;
        const invoiceTotal = subtotal - discountAmount;
        $("#invoice_date") = date;

        $("#subtotal").val( subtotal.toFixed(2) );
        $("#percent").val( (discountPercent * 100).toFixed(2) );
        $("#discount").val( discountAmount.toFixed(2) );
        $("#total").val(  invoiceTotal.toFixed(2) );
        

        // set focus on type drop-down when done
        $("#type").focus();
    });

    // set focus on type drop-down on initial load
    $("#type").focus();
});