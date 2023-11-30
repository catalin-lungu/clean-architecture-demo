import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Students from './pages/Students';
import AddStudent from './pages/AddStudent';
import Navigation from './components/Navigation';
import AddCheckIn from './pages/AddCheckIn';
import CheckIns from './pages/CheckIns';


function App() {
    return (
        <div className="container">
            <BrowserRouter>
                <Navigation />
                <div className="py-5">
                    <Routes>
                        <Route path="/" element={<Students />} />
                        <Route path="/index" element={<Students />} />
                        <Route path="/students" element={<Students />} />
                        <Route path="/add-student" element={<AddStudent />} />
                        <Route path="/add-checkin" element={<AddCheckIn />} />
                        <Route path="/:studentid/check-in" element={<CheckIns />} />
                    </Routes>
                </div>
            </BrowserRouter>
        </div>
    );
}

export default App;