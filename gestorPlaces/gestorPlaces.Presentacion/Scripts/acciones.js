/*-----------INICIO :Accion de aparecer o desaparecer menu y tabs----------------*/
$(document).ready(main);
function main(){
    $('.contenido').hide();
    $('.contenido:first').show();
    
    $('.tabs-nav li').click(function(){
        $('.tabs-nav li').removeClass('active');
        $(this).addClass('active');
        $('.contenido').hide();
        var contenido_Activo=$(this).find('a').attr('href');
        $(contenido_Activo).fadeIn();
    })
    
    $('.btn-menu').on('click',function(){
	$('nav').toggleClass('mostrar');
        
});    
};
/*-----------FIN :Accion de aparecer o desaparecer  menu y tabs----------------*/

/*-----------INICIO :colores tabs----------------*/
 $('#pestana1').click(function(){
    $('#pestana1').css({
                    'background-color': '#3ba1c7'});
    $('#pestana1 a').css({'color': '#f2fbff'});
     
    $('#pestana2').css({
                    'background-color': 'transparent'});
    $('#pestana2 a').css({'color': '#3ba1c7'});
     
    });

 $('#pestana2').click(function(){
    $('#pestana1').css({
                    'background-color': 'transparent'});
    $('#pestana1 a').css({'color': '#3ba1c7'});
     
    $('#pestana2').css({
                    'background-color': '#3ba1c7'});
    $('#pestana2 a').css({'color': '#f2fbff'});
     
    });
/*-----------FIN :colores tabs----------------*/


/*-----------INICIO :ventana modal informacion----------------*/
function openModal(){
        $('.ventanaModal').slideDown('slow');
    }
        function closeModal(){
        $('.ventanaModal').slideUp('fast');
    }
/*-----------Fin :ventana modal informacion----------------*/
/*-----------INICIO :ventana modal registro empresas----------------*/
function openModalR(){
        $('.ventanaModalR').slideDown('slow');
    }
        function closeModalR(){
        $('.ventanaModalR').slideUp('fast');
    }
/*-----------Fin :ventana modal registro empresas----------------*/
/*-----------INICIO :ventana modal registro clientes----------------*/
function openModalRClientes(){
        $('.ventanaModalRClientes').slideDown('slow');
    }
        function closeModalRClientes(){
        $('.ventanaModalRClientes').slideUp('fast');
    }
/*-----------Fin :ventana modal registro clientes----------------*/
/*-----------INICIO :ventana modal edicion empresa----------------*/
function openModalEditEmpresas(){
        $('.ventanaModal-edit-em').slideDown('slow');
    }
        function closeModalEditEmpresas(){
        $('.ventanaModal-edit-em').slideUp('fast');
    }
/*-----------Fin :ventana modal  edicion empresa----------------*/
/*-----------INICIO :ventana modal  edicion cliente----------------*/
function openModalEditClie(){
        $('.ventanaModal-edit-cli').slideDown('slow');
    }
        function closeModalEditcli(){
        $('.ventanaModal-edit-cli').slideUp('fast');
    }
/*-----------Fin :ventana modal  edicion empresa----------------*/

/*--------------------INICIO: obtener posicion de pagina------------------*/
var loc = window.location; // encapsulas el objeto location
var links = $('nav li a'); // obtienes todos los links dentro de tu nav
var lis = $('nav li'); // obtienes los objetos lista de tu nav

// Por cada objeto lista, obtienes su indice de iteración y valor (ignora el valor)
lis.each(function (idx, val) {
    // Si el enlace dentro del array de links es igual al lugar exacto en donde estás
    // agrega la clase active
    if (links[idx].href == loc.href) {
        $(this).addClass('active');
    }
});
/*------------------FIN: obtener posicion de pagina-------------------------*/

/*------------------Inicio tabs-------------------------*/

$(function () {

    $(document).ready(function () {

        $('#graficoPastel').highcharts({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: 'Porcentaje de categorias Places'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },
                    showInLegend: true
                }
            },
            series: [{
                name: 'Valor',
                colorByPoint: true,
                data: [{name: 'Restaurant',y: 56.33},
                       {name: 'Antro',y: 24.03,sliced: true,selected: true}, 
                       {name: 'Hotel',y: 10.38}, 
                       {name: 'Automotris',y: 0.2
                       }]
            }]
        });
    });
});
/*-------------------------------FIN:Grafico----------------------------*/
