import React from 'react';
import { Link } from 'react-router-dom';

function Navigation() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container">
                <div className="collapse navbar-collapse">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <Link to="/students" className="nav-link">Students</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/add-student" className="nav-link">Add Student</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/add-checkin" className="nav-link">Add Check In</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Navigation;