// Level_1---------------
let sec=document.getElementById('sec1')
let icon1=document.getElementById('icon1')
let icon2=document.getElementById('icon2')
icon1.onclick=function(){
  sec.classList.remove('mmm')
  icon1.classList.add('mmm')
  icon2.classList.remove('mmm')
}
icon2.onclick=function(){
  sec.classList.add('mmm')
  icon1.classList.remove('mmm')
  icon2.classList.add('mmm')
}
// Level_2---------------
let sec2=document.getElementById('sec2')
let icon3=document.getElementById('icon3')
let icon4=document.getElementById('icon4')

icon3.onclick=function(){
  sec2.classList.remove('mmm')
  icon3.classList.add('mmm')
  icon4.classList.remove('mmm')
}
icon4.onclick=function(){
  sec2.classList.add('mmm')
  icon3.classList.remove('mmm')
  icon4.classList.add('mmm')
}
// Level_3---------------
let sec3=document.getElementById('sec3')
let icon5=document.getElementById('icon5')
let icon6=document.getElementById('icon6')

icon5.onclick=function(){
  sec3.classList.remove('mmm')
  icon5.classList.add('mmm')
  icon6.classList.remove('mmm')
}
icon6.onclick=function(){
  sec3.classList.add('mmm')
  icon5.classList.remove('mmm')
  icon6.classList.add('mmm')
}
// Scroll Event---------------
let btn = document.getElementById('btn')
window.onscroll = function (){
  if(window.scrollY >= 250){
    btn.style.display='block'
  }
  else{
    btn.style.display='none'
  }
  btn.onclick=function (){
    window.scrollTo({
      top:0,
      behavior:'smooth',
    })
  }
}
// Nav_Responsive-----------
let navOne = document.getElementById('navOne')
let navList = document.getElementById('navList')
navOne.onclick=function list(){
    navList.classList.toggle('lestsho')
}
// -----------------

function vid(id){
  let video = document.getElementById(id)

  let video1 = document.getElementById('nnn')

  let are=[
    './../Videos/Html_Video/Html_Video2.mp4',
    './../Videos/Html_Video/Html_Video1.mp4',
    './../Videos/Html_Video/Html_Video3.mp4',
    './../Videos/Html_Video/Html_Video4.mp4',
    './../Videos/Html_Video/Html_Video5.mp4',
    // JavaScript------------------
    './../Videos/Js_Video/Js_Video2.mp4',
    './../Videos/Js_Video/Js_Video1.mp4',
    './../Videos/Js_Video/Js_Video3.mp4',
    './../Videos/Js_Video/Js_Video4.mp4',
    './../Videos/Js_Video/Js_Video5.mp4',
    // css-------------------------
    './../Videos/Css_Video/Css_Video2.mp4',
    './../Videos/Css_Video/Css_Video1.mp4',
    './../Videos/Css_Video/Css_Video3.mp4',
    './../Videos/Css_Video/Css_Video4.mp4',
    './../Videos/Css_Video/Css_Video5.mp4',
    // flutter---------------------
    './../Videos/Fluter_Video/Flutter_Video2.mp4',
    './../Videos/Fluter_Video/Flutter_Video1.mp4',
    './../Videos/Fluter_Video/Flutter_Video3.mp4',
    './../Videos/Fluter_Video/Flutter_Video4.mp4',
    './../Videos/Fluter_Video/Flutter_Video5.mp4',
    // java------------------------
    './../Videos/Java_Video/Java_Video2.mp4',
    './../Videos/Java_Video/Java_Video1.mp4',
    './../Videos/Java_Video/Java_Video3.mp4',
    './../Videos/Java_Video/Java_Video4.mp4',
    './../Videos/Java_Video/Java_Video5.mp4',
    // Larvel----------------------
    './../Videos/Larvel_Video/Larvel_Video2.mp4',
    './../Videos/Larvel_Video/Larvel_Video1.mp4',
    './../Videos/Larvel_Video/Larvel_Video3.mp4',
    './../Videos/Larvel_Video/Larvel_Video4.mp4',
    './../Videos/Larvel_Video/Larvel_Video5.mp4',
    // MySql-----------------------
    './../Videos/MySql_Video/Sql_Video2.mp4',
    './../Videos/MySql_Video/Sql_Video1.mp4',
    './../Videos/MySql_Video/Sql_Video3.mp4',
    './../Videos/MySql_Video/Sql_Video4.mp4',
    './../Videos/MySql_Video/Sql_Video5.mp4',
    // PHP-------------------------
    './../Videos/PHP_Video/PHP_Video2.mp4',
    './../Videos/PHP_Video/PHP_Video1.mp4',
    './../Videos/PHP_Video/PHP_Video3.mp4',
    './../Videos/PHP_Video/PHP_Video4.mp4',
    './../Videos/PHP_Video/PHP_Video5.mp4',
    // React------------------------
    './../Videos/React_Video/react-Video2.mp4',
    './../Videos/React_Video/react-Video1.mp4',
    './../Videos/React_Video/react-Video3.mp4',
    './../Videos/React_Video/react-Video4.mp4',
    './../Videos/React_Video/react-Video5.mp4',
  ]
  
  let int = video.getAttribute('num')
video1.setAttribute('src',are[int])

}