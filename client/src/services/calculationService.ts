import axios from 'axios';

const API_BASE_URL = 'http://localhost:5184/api/calculation';

const calculationService = {
  calculate: async (payload: { probabilityA: number; probabilityB: number; operationType: string }) => {
    const response = await axios.post(`${API_BASE_URL}/calculate`, payload, {
      headers: { 'Content-Type': 'application/json' },
    });
    return response.data;
  },
};

export default calculationService;
