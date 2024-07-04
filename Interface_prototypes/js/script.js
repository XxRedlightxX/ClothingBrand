// script.js
document.addEventListener('DOMContentLoaded', () => {
    const monthYearElement = document.getElementById('month-year');
    const datesElement = document.getElementById('dates');
    const modal = document.getElementById('modal');
    const modalDate = document.getElementById('modal-date');
    const span = document.getElementsByClassName('close')[0];

    const now = new Date();
    const year = now.getFullYear();
    const month = now.getMonth();
    const firstDayOfMonth = new Date(year, month, 1).getDay();
    const lastDateOfMonth = new Date(year, month + 1, 0).getDate();
    const lastDayOfLastMonth = new Date(year, month, 0).getDate();

    const monthNames = [
        'January', 'February', 'March', 'April', 'May', 'June',
        'July', 'August', 'September', 'October', 'November', 'December'
    ];

    monthYearElement.textContent = `${monthNames[month]} ${year}`;

    // Previous month's days
    for (let i = firstDayOfMonth; i > 0; i--) {
        const dateElement = document.createElement('div');
        dateElement.classList.add('date', 'prev-month');
        dateElement.textContent = lastDayOfLastMonth - i + 1;
        datesElement.appendChild(dateElement);
    }

    // Current month's days
    for (let i = 1; i <= lastDateOfMonth; i++) {
        const dateElement = document.createElement('div');
        dateElement.classList.add('date');
        dateElement.textContent = i;
        dateElement.addEventListener('click', () => {
            modal.style.display = 'block';
            modalDate.textContent = `Selected Date: ${monthNames[month]} ${i}, ${year}`;
        });
        datesElement.appendChild(dateElement);
    }

    // Next month's days
    const totalDates = firstDayOfMonth + lastDateOfMonth;
    const remainingDates = totalDates % 7;
    if (remainingDates !== 0) {
        for (let i = 1; i <= 7 - remainingDates; i++) {
            const dateElement = document.createElement('div');
            dateElement.classList.add('date', 'next-month');
            dateElement.textContent = i;
            datesElement.appendChild(dateElement);
        }
    }

    // Close the modal
    span.onclick = () => {
        modal.style.display = 'none';
    }

    window.onclick = (event) => {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }
});
