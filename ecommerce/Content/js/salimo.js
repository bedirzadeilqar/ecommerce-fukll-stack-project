

window.addEventListener("scroll",function(){
  var header = document.querySelector("header");
  header.classList.toggle('sticky',window.scrollY > 0);
});

var menu = document.querySelector('.menu');
var menuBtn  = document.querySelector('.menu-btn');
var closeBtn = document.querySelector('.close-btn');

menuBtn.addEventListener("click",() => {
  menu.classList.add('active');
});

closeBtn.addEventListener("click",() =>{
  menu.classList.remove('active');
})








let slideIndex = 0;
let slider = document.querySelector(".slider");
let slides = document.querySelector(".slides");
let slide = document.querySelectorAll(".slide");
let dots = document.querySelectorAll(".dots span")

showslide();

function plusslide(position) {
    slideIndex += position;

    if (slideIndex > slide.length) {
        slideIndex = 1;
    }
    else if (slideIndex < 1) {
        slideIndex = slide.length;
    }

    // Defaultly active class is removed from all dots
    for (let i = 0; i < dots.length; i++) {
        const element = dots[i];
        element.classList.remove("dot-active");
    }

    slides.style.left = `-${slideIndex - 1}00%`;
    dots[slideIndex - 1].classList.add("dot-active");
}

function currentslide(index) {
    if (index > slide.length) {
        index = 1;
    }
    else if (index < 1) {
        index = slide.length;
    }

    // Defaultly active class is removed from all dots
    for (let i = 0; i < dots.length; i++) {
        const element = dots[i];
        element.classList.remove("dot-active");
    }

    slides.style.left = `-${index - 1}00%`;
    dots[index - 1].classList.add("dot-active");

    slideIndex = index;
}

function showslide() {
    slideIndex++;

    if (slideIndex > slide.length) {
        slideIndex = 1;
    }
    else if (slideIndex < 1) {
        slideIndex = slide.length;
    }

    // Defaultly active class is removed from all dots
    for (let i = 0; i < dots.length; i++) {
        const element = dots[i];
        element.classList.remove("dot-active");
    }

    slides.style.left = `-${slideIndex - 1}00%`;
    dots[slideIndex - 1].classList.add("dot-active");
}


let interval = setInterval(()=> {
    showslide();
} , 3000);   // Change every image after 3 seconds

slider.addEventListener("mouseover" , ()=> {
    clearInterval(interval);     // onHover Stop Changing every image after 3 seconds 
});

slider.addEventListener("mouseout" , ()=> {
    interval = setInterval(()=> {
        showslide();   
    } , 3000);    // on mouseout from slide then again start Changing every image after 3  seconds 
});

function openCity(evt, cityName) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("tablinks");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(" active", "");
  }
  document.getElementById(cityName).style.display = "block";
  evt.currentTarget.className += " active";
}


(function($)
{
	"use strict";
	
	
	jQuery(window).on('load', function() {
		preloader();
		
		
		if(jQuery('.gallery-outer .gallery-items').length > 0){
			jQuery('.gallery-outer .gallery-items').filterizr();
		}
		jQuery('#filter-list li').on("click", function(){
			jQuery('#filter-list li').removeClass('active');
			jQuery(this).addClass('active');
		});
	});
	
	
	
	
	function preloader(){
		jQuery(".preloaderimg").fadeOut();
		jQuery(".preloader").delay(200).fadeOut("slow").delay(200, function(){
			jQuery(this).remove();
		});
	}
	
	
	
})(jQuery);

!function(a,b){"use strict";if(!b)throw new Error("Filterizr requires jQuery to work.");
var c=function(a){this.init(a)};c.prototype={init:function(a){this.root={x:0,y:0,w:a}},fit:function(a){var b,c,d,e=a.length,f=e>0?a[0].h:0;for(this.root.h=f,b=0;b<e;b++)d=a[b],(c=this.findNode(this.root,d.w,d.h))?d.fit=this.splitNode(c,d.w,d.h):d.fit=this.growDown(d.w,d.h)},findNode:function(a,b,c){return a.used?this.findNode(a.right,b,c)||this.findNode(a.down,b,c):b<=a.w&&c<=a.h?a:null},splitNode:function(a,b,c){return a.used=!0,a.down={x:a.x,y:a.y+c,w:a.w,h:a.h-c},a.right={x:a.x+b,y:a.y,w:a.w-b,h:c},a},growDown:function(a,b){var c;return this.root={used:!0,x:0,y:0,w:this.root.w,h:this.root.h+b,down:{x:0,y:this.root.h,w:this.root.w,h:b},right:this.root},(c=this.findNode(this.root,a,b))?this.splitNode(c,a,b):null}},b.fn.filterizr=function(){var a=this,c=arguments;if(a._fltr||(a._fltr=b.fn.filterizr.prototype.init(a,"object"==typeof c[0]?c[0]:void 0)),"string"==typeof c[0]){if(c[0].lastIndexOf("_")>-1)throw new Error("Filterizr error: You cannot call private methods");if("function"!=typeof a._fltr[c[0]])throw new Error("Filterizr error: There is no such function");a._fltr[c[0]](c[1],c[2])}return a},b.fn.filterizr.prototype={init:function(a,c){var d=b(a).extend(b.fn.filterizr.prototype);return d.options={animationDuration:.5,callbacks:{onFilteringStart:function(){},onFilteringEnd:function(){},onShufflingStart:function(){},onShufflingEnd:function(){},onSortingStart:function(){},onSortingEnd:function(){}},delay:0,delayMode:"progressive",easing:"ease-out",filter:"all",filterOutCss:{opacity:0,transform:"scale(0.5)"},filterInCss:{opacity:1,transform:"scale(1)"},layout:"sameSize",setupControls:!0},0===arguments.length&&(c=d.options),1===arguments.length&&"object"==typeof arguments[0]&&(c=arguments[0]),c&&d.setOptions(c),d.css({padding:0,position:"relative"}),d._lastCategory=0,d._isAnimating=!1,d._isShuffling=!1,d._isSorting=!1,d._mainArray=d._getFiltrItems(),d._subArrays=d._makeSubarrays(),d._activeArray=d._getCollectionByFilter(d.options.filter),d._toggledCategories={},d._typedText=b("input[data-search]").val()||"",d._uID="xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g,function(a){var b=16*Math.random()|0;return("x"==a?b:3&b|8).toString(16)}),d._setupEvents(),d.options.setupControls&&d._setupControls(),d.filter(d.options.filter),d},filter:function(a){var b=this,c=b._getCollectionByFilter(a);b.options.filter=a,b.trigger("filteringStart"),b._handleFiltering(c),b._isSearchActivated()&&b.search(b._typedText)},toggleFilter:function(a){var b=this,c=[];b.trigger("filteringStart"),a&&(b._toggledCategories[a]?delete b._toggledCategories[a]:b._toggledCategories[a]=!0),b._multifilterModeOn()?(c=b._makeMultifilterArray(),b._handleFiltering(c),b._isSearchActivated()&&b.search(b._typedText)):(b.filter("all"),b._isSearchActivated()&&b.search(b._typedText))},search:function(a){var b=this,c=b._multifilterModeOn()?b._makeMultifilterArray():b._getCollectionByFilter(b.options.filter),d=[],e=0;if(b._isSearchActivated())for(e=0;e<c.length;e++){var f=c[e].text().toLowerCase().indexOf(a.toLowerCase())>-1;f&&d.push(c[e])}if(d.length>0)b._handleFiltering(d);else if(b._isSearchActivated())for(e=0;e<b._activeArray.length;e++)b._activeArray[e]._filterOut();else b._handleFiltering(c)},shuffle:function(){var a=this;a._isAnimating=!0,a._isShuffling=!0,a.trigger("shufflingStart"),a._mainArray=a._fisherYatesShuffle(a._mainArray),a._subArrays=a._makeSubarrays();var b=a._multifilterModeOn()?a._makeMultifilterArray():a._getCollectionByFilter(a.options.filter);a._isSearchActivated()?a.search(a._typedText):a._placeItems(b)},sort:function(a,b){var c=this;if(a=a||"domIndex",b=b||"asc",c._isAnimating=!0,c._isSorting=!0,c.trigger("sortingStart"),"domIndex"!==a&&"sortData"!==a&&"w"!==a&&"h"!==a)for(var e=0;e<c._mainArray.length;e++)c._mainArray[e][a]=c._mainArray[e].data(a);c._mainArray.sort(c._comparator(a,b)),c._subArrays=c._makeSubarrays();var f=c._multifilterModeOn()?c._makeMultifilterArray():c._getCollectionByFilter(c.options.filter);c._isSearchActivated()?c.search(c._typedText):c._placeItems(f)},setOptions:function(a){var b=this,c=0;for(var d in a)b.options[d]=a[d];if(b._mainArray&&(a.animationDuration||a.delay||a.easing||a.delayMode))for(c=0;c<b._mainArray.length;c++)b._mainArray[c].css("transition","all "+b.options.animationDuration+"s "+b.options.easing+" "+b._mainArray[c]._calcDelay()+"ms");a.callbacks&&(a.callbacks.onFilteringStart||(b.options.callbacks.onFilteringStart=function(){}),a.callbacks.onFilteringEnd||(b.options.callbacks.onFilteringEnd=function(){}),a.callbacks.onShufflingStart||(b.options.callbacks.onShufflingStart=function(){}),a.callbacks.onShufflingEnd||(b.options.callbacks.onShufflingEnd=function(){}),a.callbacks.onSortingStart||(b.options.callbacks.onSortingStart=function(){}),a.callbacks.onSortingEnd||(b.options.callbacks.onSortingEnd=function(){})),b.options.filterInCss.transform||(b.options.filterInCss.transform="translate3d(0,0,0)"),b.options.filterOutCss.transform||(b.options.filterOutCss.transform="translate3d(0,0,0)")},_getFiltrItems:function(){var a=this,c=b(a.find(".filtr-item")),e=[];return b.each(c,function(c,f){var g=b(f).extend(d)._init(c,a);e.push(g)}),e},_makeSubarrays:function(){for(var a=this,b=[],c=0;c<a._lastCategory;c++)b.push([]);for(c=0;c<a._mainArray.length;c++)if("object"==typeof a._mainArray[c]._category)for(var d=a._mainArray[c]._category.length,e=0;e<d;e++)b[a._mainArray[c]._category[e]-1].push(a._mainArray[c]);else b[a._mainArray[c]._category-1].push(a._mainArray[c]);return b},_makeMultifilterArray:function(){for(var a=this,b=[],c={},d=0;d<a._mainArray.length;d++){var e=a._mainArray[d],f=!1,g=e.domIndex in c==!1;if(Array.isArray(e._category)){for(var h=0;h<e._category.length;h++)if(e._category[h]in a._toggledCategories){f=!0;break}}else e._category in a._toggledCategories&&(f=!0);g&&f&&(c[e.domIndex]=!0,b.push(e))}return b},_setupControls:function(){var a=this;b("*[data-filter]").click(function(){var c=b(this).data("filter");a.options.filter!==c&&a.filter(c)}),b("*[data-multifilter]").click(function(){var c=b(this).data("multifilter");"all"===c?(a._toggledCategories={},a.filter("all")):a.toggleFilter(c)}),b("*[data-shuffle]").click(function(){a.shuffle()}),b("*[data-sortAsc]").click(function(){var c=b("*[data-sortOrder]").val();a.sort(c,"asc")}),b("*[data-sortDesc]").click(function(){var c=b("*[data-sortOrder]").val();a.sort(c,"desc")}),b("input[data-search]").keyup(function(){a._typedText=b(this).val(),a._delayEvent(function(){a.search(a._typedText)},250,a._uID)})},_setupEvents:function(){var c=this;b(a).resize(function(){c._delayEvent(function(){c.trigger("resizeFiltrContainer")},250,c._uID)}),c.on("resizeFiltrContainer",function(){c._multifilterModeOn()?c.toggleFilter():c.filter(c.options.filter)}).on("filteringStart",function(){c.options.callbacks.onFilteringStart()}).on("filteringEnd",function(){c.options.callbacks.onFilteringEnd()}).on("shufflingStart",function(){c._isShuffling=!0,c.options.callbacks.onShufflingStart()}).on("shufflingEnd",function(){c.options.callbacks.onShufflingEnd(),c._isShuffling=!1}).on("sortingStart",function(){c._isSorting=!0,c.options.callbacks.onSortingStart()}).on("sortingEnd",function(){c.options.callbacks.onSortingEnd(),c._isSorting=!1})},_calcItemPositions:function(){var a=this,d=a._activeArray,e=0,f=Math.round(a.width()/a.find(".filtr-item").outerWidth()),g=0,h=d[0].outerWidth(),i=0,j=0,k=0,l=0,m=0,n=[];if("packed"===a.options.layout){b.each(a._activeArray,function(a,b){b._updateDimensions()});var o=new c(a.outerWidth());for(o.fit(a._activeArray),l=0;l<d.length;l++)n.push({left:d[l].fit.x,top:d[l].fit.y});e=o.root.h}if("horizontal"===a.options.layout)for(g=1,l=1;l<=d.length;l++)h=d[l-1].outerWidth(),i=d[l-1].outerHeight(),n.push({left:j,top:k}),j+=h,e<i&&(e=i);else if("vertical"===a.options.layout){for(l=1;l<=d.length;l++)i=d[l-1].outerHeight(),n.push({left:j,top:k}),k+=i;e=k}else if("sameHeight"===a.options.layout){g=1;var p=a.outerWidth();for(l=1;l<=d.length;l++){h=d[l-1].width();var q=d[l-1].outerWidth(),r=0;d[l]&&(r=d[l].width()),n.push({left:j,top:k}),m=j+h+r,m>p?(m=0,j=0,k+=d[0].outerHeight(),g++):j+=q}e=g*d[0].outerHeight()}else if("sameWidth"===a.options.layout){for(l=1;l<=d.length;l++){if(n.push({left:j,top:k}),l%f==0&&g++,j+=h,k=0,g>0)for(m=g;m>0;)k+=d[l-f*m].outerHeight(),m--;l%f==0&&(j=0)}for(l=0;l<f;l++){for(var s=0,t=l;d[t];)s+=d[t].outerHeight(),t+=f;s>e?(e=s,s=0):s=0}}else if("sameSize"===a.options.layout){for(l=1;l<=d.length;l++)n.push({left:j,top:k}),j+=h,l%f==0&&(k+=d[0].outerHeight(),j=0);g=Math.ceil(d.length/f),e=g*d[0].outerHeight()}return a.css("height",e),n},_handleFiltering:function(a){for(var b=this,c=b._getArrayOfUniqueItems(b._activeArray,a),d=0;d<c.length;d++)c[d]._filterOut();b._activeArray=a,b._placeItems(a)},_multifilterModeOn:function(){var a=this;return Object.keys(a._toggledCategories).length>0},_isSearchActivated:function(){return this._typedText.length>0},_placeItems:function(a){var b=this;b._isAnimating=!0,b._itemPositions=b._calcItemPositions();for(var c=0;c<a.length;c++)a[c]._filterIn(b._itemPositions[c])},_getCollectionByFilter:function(a){var b=this;return"all"===a?b._mainArray:b._subArrays[a-1]},_makeDeepCopy:function(a){var b={};for(var c in a)b[c]=a[c];return b},_comparator:function(a,b){return function(c,d){return"asc"===b?c[a]<d[a]?-1:c[a]>d[a]?1:0:"desc"===b?d[a]<c[a]?-1:d[a]>c[a]?1:0:void 0}},_getArrayOfUniqueItems:function(a,b){var f,g,c=[],d={},e=b.length;for(f=0;f<e;f++)d[b[f].domIndex]=!0;for(e=a.length,f=0;f<e;f++)g=a[f],g.domIndex in d||c.push(g);return c},_delayEvent:function(){var b={};return function(a,c,d){if(null===d)throw Error("UniqueID needed");b[d]&&clearTimeout(b[d]),b[d]=setTimeout(a,c)}}(),_fisherYatesShuffle:function(b){for(var d,e,c=b.length;c;)e=Math.floor(Math.random()*c--),d=b[c],b[c]=b[e],b[e]=d;return b}};var d={_init:function(a,b){var c=this;return c._parent=b,c._category=c._getCategory(),c._lastPos={},c.domIndex=a,c.sortData=c.data("sort"),c.w=0,c.h=0,c._isFilteredOut=!0,c._filteringOut=!1,c._filteringIn=!1,c.css(b.options.filterOutCss).css({"-webkit-backface-visibility":"hidden",perspective:"1000px","-webkit-perspective":"1000px","-webkit-transform-style":"preserve-3d",position:"absolute",transition:"all "+b.options.animationDuration+"s "+b.options.easing+" "+c._calcDelay()+"ms"}),c.on("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd",function(){c._onTransitionEnd()}),c},_updateDimensions:function(){var a=this;a.w=a.outerWidth(),a.h=a.outerHeight()},_calcDelay:function(){var a=this,b=0;return"progressive"===a._parent.options.delayMode?b=a._parent.options.delay*a.domIndex:a.domIndex%2==0&&(b=a._parent.options.delay),b},_getCategory:function(){var a=this,b=a.data("category");if("string"==typeof b){b=b.split(", ");for(var c=0;c<b.length;c++){if(isNaN(parseInt(b[c])))throw new Error("Filterizr: the value of data-category must be a number, starting from value 1 and increasing.");parseInt(b[c])>a._parent._lastCategory&&(a._parent._lastCategory=parseInt(b[c]))}}else b>a._parent._lastCategory&&(a._parent._lastCategory=b);return b},_onTransitionEnd:function(){var a=this;a._filteringOut?(b(a).addClass("filteredOut"),a._isFilteredOut=!0,a._filteringOut=!1):a._filteringIn&&(a._isFilteredOut=!1,a._filteringIn=!1),a._parent._isAnimating&&(a._parent._isShuffling?a._parent.trigger("shufflingEnd"):a._parent._isSorting?a._parent.trigger("sortingEnd"):a._parent.trigger("filteringEnd"),a._parent._isAnimating=!1)},_filterOut:function(){var a=this,b=a._parent._makeDeepCopy(a._parent.options.filterOutCss);b.transform+=" translate3d("+a._lastPos.left+"px,"+a._lastPos.top+"px, 0)",a.css(b),a.css("pointer-events","none"),a._filteringOut=!0},_filterIn:function(a){var c=this,d=c._parent._makeDeepCopy(c._parent.options.filterInCss);b(c).removeClass("filteredOut"),c._filteringIn=!0,c._lastPos=a,c.css("pointer-events","auto"),d.transform+=" translate3d("+a.left+"px,"+a.top+"px, 0)",c.css(d)}}}(this,jQuery);


function zahir() {
    var x = document.getElementById('detailmodal');
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}



//$(document).ready(function () {
//    $('#mdl').on('click', function () {
//        alert("Zahir");
//        $('#detailmodal').hide();
//});



