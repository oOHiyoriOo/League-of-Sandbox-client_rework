function openspell1(){
    closespell2();
    $('#spell1').attr("style","border: 2px solid red;");
    $('#spellset1').removeClass("hide");
    $('#spellset1').addClass("show");
    $('#spell1').attr("onclick", "closespell1();");
    }
function closespell1(){
    $('#spell1').attr("style","");
    $('#spellset1').removeClass("show");
    $('#spellset1').addClass("hide");
    $('#spell1').attr("onclick", "openspell1();");
    
}
function usespell(spell){
    localStorage.setItem('spell1', spell);
    $('#spell1').attr("src", "assets/img/spells/Summoner_"+spell+".png");
    $('#spellset2 .hide').removeClass('hide');
    $('#spellset2 #'+spell).addClass('hide');
    closespell1();
}


// === Spell 2 === //
function openspell2(){
    closespell1();
    $('#spell2').attr("style","border: 2px solid red;");
    $('#spellset2').removeClass("hide");
    $('#spellset2').addClass("show");
    $('#spell2').attr("onclick", "closespell2();");
    
}
function closespell2(){
    $('#spell2').attr("style","");
    $('#spellset2').removeClass("show");
    $('#spellset2').addClass("hide");
    $('#spell2').attr("onclick", "openspell2();");
    
}
function usespell2(spell){
    localStorage.setItem('spell2', spell);
    $('#spell2').attr("src", "assets/img/spells/Summoner_"+spell+".png");
    $('#spellset1 .hide').removeClass('hide');
    $('#spellset1 #'+spell).addClass('hide');
    closespell2();
}