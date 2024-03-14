"use strict"
//Taylor Mommer Course Project 4/22/22

$(document).ready(() => {
let total=0;
    

 // preload the images
    $("a img").each( (index, img) => {
        const plainImg = img.src;      
        const priceImg = img.id;       

        // preload price images		
        const rolloverImage = new Image();
        rolloverImage.src = priceImg;

        // hovering image to display price 
        $(img).hover(   
            () => img.src = priceImg,  
            () => img.src = plainImg   
        ); 
    // get the item selected to add to the order 
        $(img).click(function(evt) {
            if(img.alt == 'frappucino') {
            $("#order").append($('<option>', {
                value: 1,
                text: "$2.80 - Frappucino"
            }));
            total += 2.80;
            } 
            else if(img.alt == 'burger') {
                $("#order").append($('<option>', {
                    value: 1,
                    text: "$5.00 - Burger"
                }));
                total += 5.00;
            }
            else if (img.alt == 'panini') {
                $("#order").append($('<option>', {
                    value: 1,
                    text: "$4.25 - Panini"
                }));
                total += 4.25;
            }
            else if (img.alt == 'egg salad sandwich') {
                $("#order").append($('<option>', {
                    value: 1,
                    text: "$4.75 - Egg Salad Sandwich"
                }));
                total += 4.75;
            }
            else if (img.alt == 'biscotti') {
                $("#order").append($('<option>', {
                    value: 1,
                    text: "$1.95 - Biscotti"
                }));
                total += 1.95;
            }
            else if (img.alt == 'coffee cake') {
                $("#order").append($('<option>', {
                    value: 1,
                    text: "$2.50 - Coffee Cake"
                }));
                total += 2.50;
            }
            //display the total of selected items. 
            $("#total")[0].innerHTML = "Total: $" +Number(total).toFixed(2);
    
        
        }); 
    
    }); 

    // place order button event
    $("#place_order").click( evt =>  {
        $("#order_form").submit();
    });


    //clear order button event
    $("#clear_order").click( function () {
        $("#order").empty();
        $("#total")[0].innerHTML = "&nbsp;";
        total = 0;

    });


});