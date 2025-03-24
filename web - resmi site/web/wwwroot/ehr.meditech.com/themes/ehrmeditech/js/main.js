// make sure not to conflict with CMS's jQuery...
var $jq = jQuery.noConflict();

$jq(document).ready(function () {


    // LOAD SLIDEBARS ***************************************
    $jq.slidebars();



    // ACCORDION DROPDOWN ***************************************
    $jq('.accordion__link').bind('click', function (e) {
        $jq(this).parent().find('.accordion__dropdown').slideToggle('fast'); // apply the toggle to the ul
        $jq(this).parent().toggleClass('is-expanded');
        e.preventDefault();
    });



    // ACCORDION TOGGLE ***************************************
    $jq('.js__accordion__toggle').click(function () {
        var topoflist = $jq(this).closest('.accordion__list__item').position().top;
        $jq(this).parent().slideUp(300);
        $jq("body,html").animate({
            scrollTop: Math.round(topoflist)
        }, 800);
        $jq(this).closest('.is-expanded').toggleClass('is-expanded');
        return false;
    });



    // STYLE SELECT FORM FIELDS ***************************************
    // Add class focus when selected
    $jq('body').addClass('js');

    $jq('select').each(function () {
        var $element = $jq(this);
        // Bind event handlers to <select>
        $element.on({
            'focus': function () {
                $element.addClass('focus');
            }
        });
        // Trigger the change event so the value is current
        $element.trigger('change');
    });



    // dropdown menu ***************************************
    // http://refills.bourbon.io/unstyled/
    $jq(".dropdown-container").click(function () {
        $jq(".dropdown-menu").toggleClass("show-menu");
        $jq(".dropdown-menu > li").click(function () {
            $jq(".dropdown-menu").removeClass("show-menu");
        });
        $jq(".dropdown-menu.dropdown-select > li").click(function () {
            $jq(".dropdown-container").html($jq(this).html());
        });
    });



    // remove instances of <p>&nbsp;</p> HTML ***************************************
    $jq('p').each(function () {
        $jq(this).html($jq(this).html().replace(/&nbsp;/gi, ' '));
    });


    // Modal Pop-up Box ***************************************
    $jq('.open-modal').on('click', function () {
        var opener = $jq(this);
        var modal = '#' + opener.attr('data-target');
        if ($jq(modal + ' div.modal-content').children().is('iframe')) {
            var iframe_src = $jq(modal + ' div.modal-content iframe').attr('src');
            var new_iframe_src = iframe_src + '?autoplay=1';
            $jq(modal + ' div.modal-content iframe').attr('src', new_iframe_src);
        }
        $jq('#mask,' + modal).fadeIn(200);
    });

    $jq('.close-modal').on('click', function () {
        var closer = $jq(this);
        var modal = '#' + closer.parent().attr('id');
        if (closer.next().children().is('iframe')) {
            var source = $jq(modal + ' div iframe, ' + modal.selector + ' div img').attr('src');
            var new_source = source.replace('?autoplay=1', '');
            $jq(modal + ' iframe').attr('src', '');
            $jq(modal + ' iframe').attr('src', new_source);
            $jq('#mask,' + modal).fadeOut(200);
        } else {
            $jq('#mask,' + modal).fadeOut(200);
        }
    });



    // Remove border-bottom from image links ***************************************
    $jq('img').parent('a').each(function () {
        $jq(this).css('border-bottom', 'none');
    });



    // function that expands DIV to reveal hidden content ****************************  
    $jq('.show-less').parent().css('position', 'relative');
    $jq('.show-more').replaceWith('<div class="center show-more-container"><button class="show-more btn--alternate">Show More</button></div>');

    $jq('.show-more').on('click', function () {
        // get height of hidden content inner DIV...
        var newHeight = $jq(this).parent().prev('.show-less').children('div').height();
        if ($jq(this).parent().prev('.show-less').height() < newHeight) {
            $jq(this).parent().prev('.show-less').animate({
                height: newHeight + 120
            }, 1000); // expand to show content with enough room to move button out of the way
            $jq(this).text('Show Less');
        } else {
            var setHeight = $jq(this).parent().prev('.show-less').attr('data-height');
            $jq(this).parent().prev('.show-less').animate({
                height: setHeight
            }, 1000); // collapse back down to original height
            $jq(this).text('Show More');
        }
    });


});





/*
VANILLA JS code...
*/

// create a "document is ready" function...
function ready(callbackFunc) {
    if (document.readyState !== "loading") { // Document is already ready, call the callback directly
        callbackFunc();
    } else if (document.addEventListener) { // All modern browsers to register DOMContentLoaded
        document.addEventListener("DOMContentLoaded", callbackFunc);
    } else { // Old IE browsers
        document.attachEvent("onreadystatechange", function () {
            if (document.readyState === "complete") {
                callbackFunc();
            }
        });
    }
}


/**
 * Element.closest() POLYFILL
 * https://developer.mozilla.org/en-US/docs/Web/API/Element/closest#Polyfill
 */
if (!Element.prototype.closest) {
    if (!Element.prototype.matches) {
        Element.prototype.matches = Element.prototype.msMatchesSelector || Element.prototype.webkitMatchesSelector;
    }
    Element.prototype.closest = function (s) {
        var el = this;
        var ancestor = this;
        if (!document.documentElement.contains(el)) return null;
        do {
            if (ancestor.matches(s)) return ancestor;
            ancestor = ancestor.parentElement;
        } while (ancestor !== null);
        return null;
    };
}
/**
 * Element.matches() polyfill (simple version)
 * https://developer.mozilla.org/en-US/docs/Web/API/Element/matches#Polyfill
 */
if (!Element.prototype.matches) {
    Element.prototype.matches = Element.prototype.msMatchesSelector || Element.prototype.webkitMatchesSelector;
}

var getNextSibling = function (elem, selector) {
    // Get the next sibling element
    var sibling = elem.nextElementSibling;
    // If there's no selector, return the first sibling
    if (!selector) return sibling;
    // If the sibling matches our selector, use it
    // If not, jump to the next sibling and continue the loop
    while (sibling) {
        if (sibling.matches(selector)) return sibling;
        sibling = sibling.nextElementSibling
    }
};


// workaround for using non-arrays with foreach...
var forEach = function (arr, callback) {
    Array.prototype.forEach.call(arr, callback);
};


// perform these scripts when document is ready...
ready(function () {
	
	// get the current URL...
	var cURL = window.location.href;
    
    // add target="_blank" to any link that is not internal and is missing the target="_blank"...
    var links = document.querySelectorAll('a[href]');
    forEach(links, function(item){
        var url = item.getAttribute('href');
        // using indexOf instead of startsWith in order to support IE11...
        // if URL does not contain meditech.com or vimeo.com and it does have https:// or http://, add target="_blank" (if it's missing)...       
        if( url.indexOf('http://') > -1 || url.indexOf('https://') > -1 ){
          if( 
            url.indexOf('ehr.meditech.com') < 0 
            && url.indexOf('home.meditech.com') < 0 
            && url.indexOf('customer.meditech.com') < 0 
            && url.indexOf('www.meditech.com') < 0 
            && url.indexOf('blog.meditech.com') < 0 
            && url.indexOf('info.meditech.com') < 0 
            && url.indexOf('ctdrudev.meditech.com') < 0
            && url.indexOf('ctdrutest.meditech.com') < 0
            && url.indexOf('ctdrulive.meditech.com') < 0
          ){
            if(item.target == ''){
              item.target = '_blank';
            }
          }
          else{
            if(item.target == '_blank' && url.indexOf('.pdf') < 0){
              item.target = '';
            }
          }
        }
    });


    // add current URL to email links to pass to staff forms so recipient knows what page the email is relating to...
    var eLinks = document.querySelectorAll('a[href*="contact-a-meditech-staff-member?staff="]');
    forEach(eLinks, function(item){
        item.href += '&pg=' + cURL;
    });


    // add noreferrer noopener to new window links to prevent URLs being pointed at from accessing your window DOM object (improves performance and security)...
    var tLinks = document.querySelectorAll('a[target=\"_blank\"]');
    forEach(tLinks, function(item){
        if(item.rel == ""){
            item.rel = "noreferrer noopener";
        } else {
            item.rel += " noreferrer noopener";
        }
    });


    // add "expander" class to links within "expander" DIVs...
    var expanderDivs = document.querySelectorAll('div.expander');
    forEach(expanderDivs, function (item) {
        var expanderLink = item.querySelector('a'); // find the link
        expanderLink.setAttribute('class', 'expander'); // add class
        var spanWrapper = document.createElement('span'); // create span tags
        expanderLink.parentNode.insertBefore(spanWrapper, expanderLink); // add span to DOM before link
        spanWrapper.appendChild(expanderLink); // move link into span
    });
/*
    // add "expander" class to links within "expander" BUTTONS...
    var expanderButtons = document.querySelectorAll('button.expander-button');
    forEach(expanderButtons, function (item) {
        var expanderSpan = item.querySelector('span'); // find the SPAN tag
        expanderSpan.setAttribute('class', 'expander'); // add class
    });
	*/	

    // check all click events...
    window.addEventListener('click', function(e) {


        // expanding/collapsing elements (requires "expand" class on element)...
			  // DIV version...
        if (e.target.className.split(' ').indexOf('expander') > -1) {
            var nextCollapsible = getNextSibling(e.target.closest('div.expander'), '.collapsible');
            if (window.getComputedStyle(nextCollapsible).display == 'none') {
                nextCollapsible.style.display = 'inline-block';
                e.target.closest('div.expander').querySelector('span').className = 'expanded'; // change symbol
            } else {
                nextCollapsible.style.display = 'none';
                e.target.closest('div.expander').querySelector('span').className = ''; // change symbol
            }
					e.preventDefault();
        }
			
        // expanding/collapsing elements (requires "expand" class on element)...
			  // BUTTON version...
        if (e.target.className.split(' ').indexOf('expander-button') > -1) {
            var nextCollapsible = e.target.nextElementSibling;
            if (window.getComputedStyle(nextCollapsible).display == 'none') {
                nextCollapsible.style.display = 'inline-block';
								e.target.classList.add('expanded');
            } else {
                nextCollapsible.style.display = 'none';
								e.target.classList.remove('expanded');
            }
					e.preventDefault();
        }

			
        // play/pause button for videos...
        if (e.target.className.split(' ').indexOf('videoButton') > -1) {
            // expects previous element to be a video tag...
            var targetVideo = e.target.previousElementSibling;
            if (targetVideo.paused) {
                targetVideo.play();
                e.target.querySelector('span').textContent = "Pause Demo";
                e.target.classList.remove('play');
                e.target.classList.add('pause');
            } else {
                targetVideo.pause();
                e.target.querySelector('span').textContent = "Play Demo";
                e.target.classList.remove('pause');
                e.target.classList.add('play');
            }
        }
        // play/pause button sync with video click action...
        if (e.target.className.split(' ').indexOf('demo') > -1) {
            var videoButton = e.target.nextElementSibling;
            if (e.target.paused) {
                e.target.play();
                videoButton.querySelector('span').textContent = "Pause Demo";
                videoButton.classList.remove('play');
                videoButton.classList.add('pause');
            } else {
                e.target.pause();
                videoButton.querySelector('span').textContent = "Play Demo";
                videoButton.classList.remove('pause');
                videoButton.classList.add('play');
            }
        }			
			
			
			
        // Click 1 object (clicker) and Swap other object (reactor)...
				function swapOnClick(id){
					var clickers = document.querySelectorAll('button.js-clicker');
					forEach( clickers, function(item){
						if( item.className.split(' ').indexOf('active') > -1 ){
							item.classList.remove('active');
						}
					});
					var reactors = document.querySelectorAll('#js-reactor > div');
					forEach(reactors, function (item){
						item.style.display = 'none';
					});
					var reactorId = id.substring(1);
					document.querySelector('#js-reactor > div#r' + reactorId).style.display = 'block';
				}
				// if button is clicked...
        if( e.target.className.split(' ').indexOf('js-clicker') > -1 ) {
					var clickerId = e.target.id;
					swapOnClick(clickerId);
        }
				// if button's child element is clicked...
				if( e.target.parentElement.className.split(' ').indexOf('js-clicker') > -1) {
					var clickerId = e.target.parentElement.id;
					swapOnClick(clickerId);
        }
			

    });




});
