function toggleSidebar() {
    const sidebar = document.getElementById('sidebar');
    sidebar.classList.toggle('open');
}

document.querySelectorAll('.dropdown-toggle').forEach(toggle => {
    toggle.addEventListener('click', function(event) {
        event.preventDefault();
        const dropdownMenu = this.nextElementSibling;
        dropdownMenu.style.display = dropdownMenu.style.display === 'block' ? 'none' : 'block';
    });
});
