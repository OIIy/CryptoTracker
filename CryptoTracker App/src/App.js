import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './index.css';
import './global.css';
import CryptoTable from './components/CryptoTable/CryptoTable';
import Search from './components/Search/Search';
import { FaBars } from 'react-icons/fa'
import Login from './components/Login/Login';

function App() {
  return (
    <div className='wrapper'>
      <header className='py-5'>
        <nav className='navbar navbar-expand-lg navbar-dark fixed-top'>
          <div className='container-fluid'>
          <button 
              className="navbar-toggler"
              type="button"
              data-mdb-toggle="collapse"
              data-mdb-target="#navbarExample01"
              aria-controls="navbarExample01"
              aria-expanded="false"
              aria-label="Toggle navigation"
            >
            <FaBars />
            </button>
            <div className="collapse navbar-collapse justify-content-between" id="navbar">
              <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                <li className="nav-item active">
                  <a className="nav-link" aria-current="page" href="#">Crytpo</a>
                </li>
              </ul>
              {/* <Login /> */}
            </div>
          </div>
        </nav>
      </header>
      <div className='body my-5 mx-5'>
        <div className='container'>
          <div className='row'>
            <Search />
          </div>
          <div className='row py-5'>
            <CryptoTable />
          </div>
        </div>
      </div>
      <div className='footer'></div>
    </div>
    )
  }

export default App
