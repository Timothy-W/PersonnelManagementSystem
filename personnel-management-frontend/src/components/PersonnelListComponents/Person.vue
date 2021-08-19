<template>
  <div class="person" @dblclick="routeToPersonDetails">
    <h3>
      {{ person.firstName }} {{ person.lastName }}
      <div class="buttons">
        <i @click="toggleEditMode()" class="fas fa-edit"></i>
        <i @click="$emit('delete-person', person.id)" class="fas fa-times"></i>
      </div>
    </h3>
    <p>Rank: {{ person.rank }}</p>
    <div v-if="!inDisplayMode">
      <EditPersonnelForm
        :personToUpdate="person"
        @update-person="emiteUpdatePerson"
      />
    </div>
  </div>
</template>


<script>
import EditPersonnelForm from "./EditPersonnelForm.vue";

export default {
  name: "Person",
  props: {
    person: Object,
  },
  components: {
    EditPersonnelForm,
  },
  emits: ["delete-person", "update-person"],
  data() {
    return {
      inDisplayMode: true,
    };
  },
  methods: {
    toggleEditMode() {
      this.inDisplayMode = !this.inDisplayMode;
    },
    emiteUpdatePerson(person) {
      //console.log("Person "+ JSON.stringify(person)) //good
      this.toggleEditMode();
      this.$emit("update-person", person);
    },
    routeToPersonDetails() {
      this.$router.push({
        name: "PersonDetails",
        params: { id: this.person.id },
      });
    },
  },
};
</script>


<style scope>
.fa-times {
  color: red;
  margin-left: 5px;
  margin-right: 5px;
}

.fa-edit {
  color: blue;
  margin-left: 5px;
  margin-right: 5px;
}

.person {
  background: #f4f4f4;
  margin: 5px;
  padding: 10px 20px;
  cursor: pointer;
}
.person.reminder {
  border-left: 5px solid green;
}
.person h3 {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>