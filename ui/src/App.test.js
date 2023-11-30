import { render, screen } from '@testing-library/react';
import App from './App';

test('renders navigation in App', () => {
    render(<App />);
    const navElement = screen.getByRole('navigation');
    expect(navElement).toBeInTheDocument();
});