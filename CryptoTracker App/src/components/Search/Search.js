import React, { useState, useEffect } from "react";
import axios from "../../api/axios";
import CryptoTable from "../CryptoTable/CryptoTable";
import Dropdown from "./Dropdown";
import './Search.css';

function Search() {
    const [cryptoList, setCryptoList] = useState([]); 
    const [cryptoResults, setCryptoResults] = useState([]);
    const [searchString, setSearchString] = useState('');
    const [searchDisabled, setSearchDisabled] = useState(true);

    useEffect(() => {
        getCryptoList();
    }, [])

    useEffect(() => {
        if (cryptoList.length) {
            setSearchDisabled(false);
        }
    }, [cryptoList])

    useEffect(() => {
        renderResultsDropdown();
    }, [cryptoResults])

    const renderResultsDropdown = () => {
        return <Dropdown data={cryptoResults}/>
    }

    const getCryptoList = async () => {
        await axios.get('crypto/list').then(response => {
            setCryptoList(response.data);
        });
    }
 
    const liveSearch = val => {
        var results = cryptoList.filter(x => x.CodeDescription.includes(val))
        results = results.slice(0, 15);
        console.log(results);
        setSearchString(val);
        setCryptoResults(results);
    }

    return (
        <div class="input-group input-group-lg">
            <input type="text" class="form-control" aria-label="Large" aria-describedby="inputGroup-sizing-sm" placeholder="Start Searching for Cryptocurrencies"
                onChange={e => liveSearch(e.target.value)}
                disabled={searchDisabled}
            />
            {searchString.length >= 3 && <Dropdown data={cryptoResults}></Dropdown>}
        </div>
    )
}

export default Search;