// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//https://stackoverflow.com/questions/49686741/detect-unsupported-browser-version-and-show-specific-div-with-message
( function ( window ) {
    //Get Browser Type
    var browser = {
        /** Define Browser Type*/
        type:/** Whether we are using a IE Browser or not. */
        typeof ( window.attachEvent ) === 'function' && !( Object.prototype.toString.call( window.opera ) == '[object Opera]' )
            ? 'IE'
            /** Whether we are using a Opera Browser or not. */
            : ( Object.prototype.toString.call( window.opera ) == '[object Opera]' || navigator.userAgent.indexOf( 'Opera Mini' ) > -1 )
                ? 'Opera'
                /** Whether we are using a WebKit Type Browser or not. */
                : ( navigator.userAgent.indexOf( 'AppleWebKit/' ) > -1 )
                    ? 'WebKit'
                    /** Whether we are using a Gecko Type Browser or not. */
                    : ( navigator.userAgent.indexOf( 'Gecko' ) > -1 && navigator.userAgent.indexOf( 'KHTML' ) === -1 )
                        ? 'Gecko'
                        /** Whether we are using a Apple Browser or not. */
                        : ( /Apple.*Mobile/.test( navigator.userAgent ) )
                            ? 'MobileSafari'
                            : undefined
    };
    //Get Browser Version
    browser.version = function () {
        let ua; ua = navigator.userAgent;
        return this.type === 'Gecko' ? /** Whether this browser type is Gecko*/function ( a ) {
            let rv = -1, re = new RegExp( "rv:([0-9]{1,}[\.0-9]{0,})" );
            re.exec( ua ) !== null ? rv = parseFloat( RegExp.$1 ) : '';
            if ( ua.indexOf( 'Firefox/' ) > 0 ) { a.name = 'Firefox'; return rv; }
            if ( ua.indexOf( 'Trident/' ) > 0 ) {/** IE > 10*/a.name = 'IE'; return rv; }
            return rv;
        }( this ) : this.type === 'WebKit' ?/** Whether this browser type is WebKit*/ function ( a, b ) {
            let rv = -1, re;
            re = ua.match( /Opera|OPR\/([0-9]+)\./ );
            if ( null !== re ) {
                rv = parseInt( re[1], 10 ); a.name = 'Opera';
                return rv;
            }
            re = ua.match( /Chrom(e|ium)\/([0-9]+)\./ );
            if ( null !== re ) {
                rv = parseInt( re[2], 10 ); a.name = 'Chrome';
                return rv;
            }
            re = /AppleWebKit\/([\d.]+)/.exec( navigator.userAgent );
            if ( null !== re ) {
                rv = parseFloat( re[1] ); a.name = 'Safari';
                return rv;
            }
            return rv;
        }( this ) : this.type === 'IE' ?/** Whether this browser type is IE (IE version < 9)*/ function ( a ) {
            let rv = -1, re;
            re = new RegExp( "MSIE ([0-9]{1,}[\.0-9]{0,})" );
            return re.exec( ua ) !== null ? ( rv = parseFloat( RegExp.$1 ), a.name = 'IE', rv ) : rv;
        }( this ) : this.type === 'Opera' ?/** Whether this browser type is Opera*/ function ( a ) {
            let rv = -1;
            try {
                rv = navigator.userAgent.match( /Version\/([1-9]+\.[0-9]{2})/ )[1]; a.name = 'Opera';
                return rv;
            } catch ( ex ) {
                return rv;
            }
        }( this ) : /** Undefined browser type define*/ -1;
    }.call( browser );

    window.browser = browser;

}(window));
if ( ( browser.name === 'Chrome' && browser.version <= 67 )
    || ( browser.name === 'IE' && browser.version < 11 )
    || ( browser.name === 'Firefox' && browser.version <= 50 ) ) {
    // Not Supported
    var style = document.createElement('style');
    style.type = 'text/css';
    style.innerHTML = '* { filter: none !important; }';
    document.getElementsByTagName('head')[0].appendChild(style);
} else {
    //Supported or Undefined Browser
}

// Inicializa o SideNav
$(document).ready(function(){
    $('.sidenav').sidenav();
});

// Inicializa o ToolTip
$(document).ready(function(){
    $('.tooltipped').tooltip();
});

// Inicializa o Modal
$(document).ready(function(){
    $('.modal').modal();
});


// Funções para o Modo Aurélio *********************************************************
function trocaTextoFrase(texto){
    let iframe = document.getElementById('aureliolIframe');
    let innerDoc = (iframe.contentDocument) ? iframe.contentDocument : iframe.contentWindow.document;
    innerDoc.getElementById('aurPhraseWrap').innerHTML = texto;
}


// Funções para a tela Minhas Fases *********************************************************
function trocaIndexFase(index, desafios){
    AchaDesafioCorreto(index, desafios);
    let indexText = document.getElementById('indexFase');
    indexText.innerHTML = index;
}

// Função para carregar questões da fase atual
function AchaDesafioCorreto(index, desafios){

    let obj = JSON.parse(desafios);
    for(i = 0; i < obj.length; i++){
        if(obj[i].Chave === index){
            console.log("ACHEI!");
            chamaMetodoEspecifico(obj[i]);
            return;
        }else{
            console.log("NÃO ACHEI!");
        }
    }

}

function chamaMetodoEspecifico(desafios){
    document.getElementById('myQuestions').innerHTML = "";
    let footerButtons = document.getElementById('footerButtons');
    footerButtons.innerHTML = "";

    if(desafios.IdTipoFase === 1){ // Aurélio

    }else if(desafios.IdTipoFase === 2){ // Explorador

    }else if(desafios.IdTipoFase === 3){ // Lacuna

    }if(desafios.IdTipoFase === 4){ // Normal
        console.log(desafios);
        var element = document.createElement('a');
        element.classList.add("waves-effect", "waves-green", "btn-flat");
        element.onclick = function(){
            chamaTelaEditar(desafios.Id);
        };
        
        var iElement = document.createElement("i");
        iElement.classList.add("material-icons");
        iElement.innerHTML = 'edit';
        
        element.appendChild(iElement);
        footerButtons.appendChild(element);

        element = document.createElement('a');
        element.classList.add("modal-close","waves-effect", "waves-green", "btn-flat");
        
        iElement = document.createElement("i");
        iElement.classList.add("material-icons");
        iElement.innerHTML = 'clear';
        
        element.appendChild(iElement);
        footerButtons.appendChild(element);
        console.log(desafios.desafiosNormal.length)
        let numPalavras = desafios.desafiosNormal.length
        for(i = 0; i < numPalavras; i++){
            console.log("óia   " + desafios.desafiosNormal[i].Palavra);
            carregaQuestoes(i, desafios.desafiosNormal[i].Palavra);
        }     
    }
}

function carregaQuestoes(index, texto){
    let myQuestionsModal = document.getElementById('myQuestions');
    myQuestionsModal.innerHTML += "<li class='collection-item'><div>"+index+" - "+texto+"<div class='secondary-content rightSpace'>Erros: 423</div><div class='secondary-content rightSpace'>Acertos: 3000</div></div></li>";
}

// Quando o usuário clica no botão para apagar uma fase
function taQuerendoApagarFase(idFase){
    document.getElementById('idFaseParaApagar').innerHTML = idFase
}
       
function chamaTelaEditar(idFase){
    console.log(idFase);
                 
    var url = "/CriarFase/CarregarParaEditar"; // Url que será enviado
                
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    //xhr.setRequestHeader('Content-type','application/x-www-form-urlencoded');
    xhr.setRequestHeader('Content-type','application/json');
    xhr.onload = function () {
        if (xhr.readyState == 4 && xhr.status == "201") {
            console.log(xhr.responseText);
        } else {
            console.error(xhr.responseText);
        }

        var jsonReceived = JSON.parse(xhr.responseText);
        
        if(jsonReceived.state == 1)
            window.location.href = '/TaCertoForms/CriarFase?fase=normal'; // Redireciona
        else
            console.log("Deu ruim no server side");
    }
    xhr.send(idFase);
}

//operacao / dados
function fetchTCF(){

}

//Toast!
var Toast = Toast || null;
document.addEventListener("DOMContentLoaded", ()=>{
    console.log("toast message  " + Toast)
    if(Toast !== null)
        M.toast({html: Toast, classes: 'rounded green lighten-1'});
});