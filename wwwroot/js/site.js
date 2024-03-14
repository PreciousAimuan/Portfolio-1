// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var tabLinks = document.getElementsByClassName('tab-links');
var tabContents = document.getElementsByClassName('tab-contents');

function openTab(tabName) {
    for (let tabLink of tabLinks) {
        tabLink.classList.remove("active-link");
    }

    for (let tabContent of tabContents) {
        tabContent.classList.remove("active-tab");
    }

    event.currentTarget.classList.add('active-link');
    document.getElementById(tabName).classList.add('active-tab');
}

const header = document.querySelector("header");

window.addEventListener("scroll", function () {
    header.classList.toggle("sticky", window.scrollY > 120);

});

// ---------------- JS for Mobile Menu ------------------
var mobileMenu = document.getElementById("mobile-menu");
function openMenu() {
    mobileMenu.style.right = "0px";
}

function closeMenu() {
    mobileMenu.style.right = "-400px";
}


let menu = document.querySelector('#menu-icon');
let navlist = document.querySelector('.navlist');

menu.onclick = () => {
    menu.classList.toggle('bx-x');
    navlist.classList.toggle('active');

};

window.onscroll = () => {
    menu.classList.remove('bx-x');
    navlist.classList.remove('active');
};


/*// FOR DASHBOARD

const html = document.documentElement;
const body = document.body;
const menuLinks = document.querySelectorAll(".admin-menu a");
const collapseBtn = document.querySelector(".admin-menu .collapse-btn");
const toggleMobileMenu = document.querySelector(".toggle-mob-menu");
const switchInput = document.querySelector(".switch input");
const switchLabel = document.querySelector(".switch label");
const switchLabelText = switchLabel.querySelector("span:last-child");
const collapsedClass = "collapsed";
const lightModeClass = "light-mode";

*//*TOGGLE HEADER STATE*//*
collapseBtn.addEventListener("click", function () {
  body.classList.toggle(collapsedClass);
  this.getAttribute("aria-expanded") == "true"
    ? this.setAttribute("aria-expanded", "false")
    : this.setAttribute("aria-expanded", "true");
  this.getAttribute("aria-label") == "collapse menu"
    ? this.setAttribute("aria-label", "expand menu")
    : this.setAttribute("aria-label", "collapse menu");
});

*//*TOGGLE MOBILE MENU*//*
toggleMobileMenu.addEventListener("click", function () {
  body.classList.toggle("mob-menu-opened");
  this.getAttribute("aria-expanded") == "true"
    ? this.setAttribute("aria-expanded", "false")
    : this.setAttribute("aria-expanded", "true");
  this.getAttribute("aria-label") == "open menu"
    ? this.setAttribute("aria-label", "close menu")
    : this.setAttribute("aria-label", "open menu");
});

*//*SHOW TOOLTIP ON MENU LINK HOVER*//*
for (const link of menuLinks) {
  link.addEventListener("mouseenter", function () {
    if (
      body.classList.contains(collapsedClass) &&
      window.matchMedia("(min-width: 768px)").matches
    ) {
      const tooltip = this.querySelector("span").textContent;
      this.setAttribute("title", tooltip);
    } else {
      this.removeAttribute("title");
    }
  });
}

*//*TOGGLE LIGHT/DARK MODE*//*
if (localStorage.getItem("dark-mode") === "false") {
  html.classList.add(lightModeClass);
  switchInput.checked = false;
  switchLabelText.textContent = "Light";
}

switchInput.addEventListener("input", function () {
  html.classList.toggle(lightModeClass);
  if (html.classList.contains(lightModeClass)) {
    switchLabelText.textContent = "Light";
    localStorage.setItem("dark-mode", "false");
  } else {
    switchLabelText.textContent = "Dark";
    localStorage.setItem("dark-mode", "true");
  }
});

const NavLinks = document.getElementsByClassName('nav-link')

console.log(NavLinks[0])

for(let i=0; i<NavLinks.length; i++){
    NavLinks[i].addEventListener('click', (e) => {
        e.target.href= `#${e.target.outerText.toLowerCase()}`
        showSection(e.target.outerText.toLowerCase())
    });
}

const html = document.documentElement;
const body = document.body;
const menuLinks = document.querySelectorAll(".admin-menu a");
const collapseBtn = document.querySelector(".admin-menu .collapse-btn");
const toggleMobileMenu = document.querySelector(".toggle-mob-menu");
const switchInput = document.querySelector(".switch input");
const switchLabel = document.querySelector(".switch label");
const switchLabelText = switchLabel.querySelector("span:last-child");
const collapsedClass = "collapsed";
const lightModeClass = "light-mode";

*//*TOGGLE HEADER STATE*//*
collapseBtn.addEventListener("click", function () {
    body.classList.toggle(collapsedClass);
    this.getAttribute("aria-expanded") == "true"
        ? this.setAttribute("aria-expanded", "false")
        : this.setAttribute("aria-expanded", "true");
    this.getAttribute("aria-label") == "collapse menu"
        ? this.setAttribute("aria-label", "expand menu")
        : this.setAttribute("aria-label", "collapse menu");
});

*//*TOGGLE MOBILE MENU*//*
toggleMobileMenu.addEventListener("click", function () {
    body.classList.toggle("mob-menu-opened");
    this.getAttribute("aria-expanded") == "true"
        ? this.setAttribute("aria-expanded", "false")
        : this.setAttribute("aria-expanded", "true");
    this.getAttribute("aria-label") == "open menu"
        ? this.setAttribute("aria-label", "close menu")
        : this.setAttribute("aria-label", "open menu");
});

*//*SHOW TOOLTIP ON MENU LINK HOVER*//*
for (const link of menuLinks) {
    link.addEventListener("mouseenter", function () {
        if (
            body.classList.contains(collapsedClass) &&
            window.matchMedia("(min-width: 768px)").matches
        ) {
            const tooltip = this.querySelector("span").textContent;
            this.setAttribute("title", tooltip);
        } else {
            this.removeAttribute("title");
        }
    });
}

*//*TOGGLE LIGHT/DARK MODE*//*
if (localStorage.getItem("dark-mode") === "false") {
    html.classList.add(lightModeClass);
    switchInput.checked = false;
    switchLabelText.textContent = "Light";
}

switchInput.addEventListener("input", function () {
    html.classList.toggle(lightModeClass);
    if (html.classList.contains(lightModeClass)) {
        switchLabelText.textContent = "Light";
        localStorage.setItem("dark-mode", "false");
    } else {
        switchLabelText.textContent = "Dark";
        localStorage.setItem("dark-mode", "true");
    }
});

const NavLinks = document.getElementsByClassName('nav-link')

console.log(NavLinks[0])

for (let i = 0; i < NavLinks.length; i++) {
    NavLinks[i].addEventListener('click', (e) => {
        e.target.href = `#${e.target.outerText.toLowerCase()}`
        showSection(e.target.outerText.toLowerCase())
    });
}




function showSection(id) {
    console.log(id)
    const sections = document.querySelectorAll('section');
    sections.forEach(section => {
        if (section.id === id) {
            console.log(section)
            section.classList.add('active');
        } else {
            section.classList.remove('active');
        }
    });
}

function showSection(id) {
    console.log(id)
    const sections = document.querySelectorAll('section');
    sections.forEach(section => {
        if (section.id === id) {
            console.log(section)
            section.classList.add('active');
        } else {
            section.classList.remove('active');
        }
    });
}
*/

function showPage(pageId) {
    // Hide all sections
    var sections = document.querySelectorAll('.content-section');
    sections.forEach(function (section) {
        section.style.display = 'none';
    });

    // Show the selected section
    var selectedSection = document.getElementById(pageId);
    selectedSection.style.display = 'block';
}
