import React, { useState, useEffect } from 'react'
import axios from 'axios'
import './index.css'
import Sidebar from './components/Sidebar/Sidebar';

function App() {

  return (
      <aside>
        <Sidebar />
      </aside>
    )
  }

export default App

/** 
 * column: "...", "..."
 */