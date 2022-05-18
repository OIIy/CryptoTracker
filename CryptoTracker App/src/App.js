import React, { useState, useEffect } from 'react'
import axios from 'axios'
import './index.css'
import Sidebar from './components/Sidebar/Sidebar';
import Search from './components/Search/Search';

function App() {

  return (
      <div className="container py-3">
        <div className="row justify-content-around">
            <div className="col-6">
              <Search />
            </div>
        </div>
        <Sidebar />
      </div>
    )
  }

export default App
