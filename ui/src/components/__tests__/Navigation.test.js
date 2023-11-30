import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import Navigation from '../Navigation';

test('renders navigation links', () => {
    render(
        <MemoryRouter>
            <Navigation />
        </MemoryRouter>
    );

    const studentsLink = screen.getByText(/students/i);
    const addStudentLink = screen.getByText(/add student/i);
    const addCheckInLink = screen.getByText(/add check in/i);

    expect(studentsLink).toBeInTheDocument();
    expect(addStudentLink).toBeInTheDocument();
    expect(addCheckInLink).toBeInTheDocument();

    expect(studentsLink.getAttribute('href')).toBe('/students');
    expect(addStudentLink.getAttribute('href')).toBe('/add-student');
    expect(addCheckInLink.getAttribute('href')).toBe('/add-checkin');
});
